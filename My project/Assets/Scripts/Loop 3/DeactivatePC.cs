using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeactivatePC : MonoBehaviour
{
    [SerializeField] GameObject[] deactivateObjects;
    [SerializeField] GameObject appearanceObject;
    [SerializeField] GameObject doorChanger;
    [SerializeField] GameObject pcObject;
    [SerializeField] TMP_Text tmproText;
    [SerializeField] int numberOfInteractions;

    public void ChangeTexts()
    {
        if (numberOfInteractions >= 4)
        {
            doorChanger.TryGetComponent<InteractableObject>(out var i);
            i.OnInteract();
            DeactivateGameObjects();
            pcObject.tag = "Untagged";
        }

        else
        {
            DeactivateGameObjects();

            switch (numberOfInteractions)
            {
                case 0:
                    tmproText.text = "Rechazado: " +
                                "Debiste haber " +
                                "estudiado más ";
                    break;

                case 1:
                    tmproText.text = "Rechazado: " +
                                "Podrías haber " +
                                "elegido mejor ";
                    break;

                case 2:
                    tmproText.text = "Rechazado: " +
                                "Si hubieras " +
                                "actuado diferente";
                    break;

                case 3:
                    tmproText.text = "Rechazado: " +
                                "Si tan solo " +
                                "puedieras volver";
                    break;

                default:
                    break;
            }

            appearanceObject.SetActive(true);
            numberOfInteractions++;
        }
    }

    private void DeactivateGameObjects()
    {
        foreach (GameObject obj in deactivateObjects)
        {
            obj.SetActive(false);
        }
    }
        
}
