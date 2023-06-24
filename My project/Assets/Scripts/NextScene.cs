using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

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

    }
}
