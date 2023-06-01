using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneManager : MonoBehaviour
{
    public static ChangeSceneManager Instance { get; private set; }
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
        ChangeScene();
    }

    private void ChangeScene()
    {
        if (Input.GetKeyDown(KeyCode.P))
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
        }
    }
}
