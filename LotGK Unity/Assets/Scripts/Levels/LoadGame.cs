using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    //When the player clicks, set the loadMe boolean to true.
    //This allows the BootGame and BackToMenu scripts to load the corresponding scene.
        public bool loadMe = false;
    void OnMouseDown() {
        Debug.Log("Loading Game...");
        loadMe = true;
    }

    //At any stage, the player may press the ESC button to quit the game.
    void Update() {

        if(Input.GetKeyDown("escape")) {
            QuitGame();
        }

    }
    
    public void QuitGame()
 {  //These two options allow the user to quit either from the Unity Editor
    // or from the finished applicaiton.
     #if UNITY_EDITOR
         UnityEditor.EditorApplication.isPlaying = false;
     #else
         Application.Quit();
     #endif
 }

    
}
