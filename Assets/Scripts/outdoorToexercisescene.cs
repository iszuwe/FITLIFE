using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class outdoorToexercisescene : MonoBehaviour
{
    public string sceneToLoad;

    public void TriggerSceneChange()
    {

        SceneManager.LoadScene(sceneToLoad);
    }
}
