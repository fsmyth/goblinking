using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToWin : MonoBehaviour
{
    public GameObject loadWinTrigger;
    public Win loadWinScene;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        loadWinTrigger = GetComponent<GameObject>();
        loadWinScene = loadWinTrigger.GetComponent<Win>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        //When the trigger is called, run the LoadMaze() function
        if (loadWinScene.loadWin == true) {
            LoadWin();
        }
    }

    public void LoadWin() {
        //Load the game
       StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel() {
        //Wait for the fade-out animation to play before loading the scene.
        anim.Play("OnLoadOut");

        yield return new WaitForSeconds(2);

        SceneManager.LoadScene("winScene");
    }
}
