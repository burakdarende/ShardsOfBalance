using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenemManager : MonoBehaviour
{
    int sceneIndex = 0;
   public void StartGame()
    {
        SceneManager.LoadScene(1);

    }
    public void NextScene()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        sceneIndex = activeScene.buildIndex + 1;
        SceneManager.LoadScene(sceneIndex);
    }
}
