using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenemManager : MonoBehaviour
{
    int sceneIndex = 0;
   public void StartGame()
    {
        SceneManager.LoadScene(1);

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if(other.gameObject.CompareTag("Player")) NextScene();
        
    }
    public void NextScene()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        sceneIndex = activeScene.buildIndex + 1;
        SceneManager.LoadScene(sceneIndex);
    }
}
