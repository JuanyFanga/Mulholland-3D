using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeactivatePC : MonoBehaviour
{
    [SerializeField] GameObject[] deactivateObjects;
    [SerializeField] GameObject appearanceObject;
    [SerializeField] TMP_Text tmproText;
    [SerializeField] int numberOfInteractions;

    public void ChangeTexts()
    {
        foreach(GameObject obj in deactivateObjects)
        {
            obj.SetActive(false);
        }

        switch (numberOfInteractions)
        {
            case 0:
                tmproText.text = "Rechazado: " +
                         "Debiste haber " +
                         "Estudiado más ";
                break;

            case 1:
                tmproText.text = "Rechazado: " +
                         "Debiste haber " +
                         "mullholland 40d más ";
                break;

            default:
                break;
        }

        appearanceObject.SetActive(true);
        numberOfInteractions++;
    }


}
