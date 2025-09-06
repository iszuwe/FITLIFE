using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playbtn : MonoBehaviour
{
    public string sceneToLoad;
    // This method is called when the Play button is clicked
    public void PlayGame()
    {
        SceneManager.LoadScene(sceneToLoad); // Replace with your actual scene name
    }
}
