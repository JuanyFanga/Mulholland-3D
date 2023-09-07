using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerSingleton : MonoBehaviour
{
    public static SceneChangerSingleton Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        //ChangeSceneToDebug();
        ReturnToMainMenu();
    }

    public void ReturnToMainMenu()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            Debug.Log("Mantaining Return");
            if (Input.GetKeyDown(KeyCode.M))
            {
                Debug.Log("Back to main menu");
                SceneManager.LoadScene(0);
            }
        }
    }

    /*
    private void ChangeSceneToDebug()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangeScene();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SceneManager.LoadScene(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SceneManager.LoadScene(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SceneManager.LoadScene(6);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void ChangeScene()
    {
        int actualScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = actualScene + 1;

        Debug.Log("Next Scene is: " + nextScene);
        Debug.Log("Total of scenes is: " + SceneManager.sceneCountInBuildSettings);

        if (nextScene >= SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(0);
        }

        else
        {
            SceneManager.LoadScene(nextScene);
        }
    } */
}
