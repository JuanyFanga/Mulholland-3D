using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuInteractions : MonoBehaviour
{
    [SerializeField] private GameObject[] canvas;

    private void Awake()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ChapterSelector()
    {
        canvas[0].SetActive(false);
        canvas[1].SetActive(true);
    }

    public void Back()
    {
        canvas[0].SetActive(true);
        canvas[1].SetActive(false);
    }

    public void ChargeScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
