using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public GameObject loadTrigger;
    public LoadGame loadGame;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
        loadTrigger = GetComponent<GameObject>();
        loadGame = loadTrigger.GetComponent<LoadGame>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        //When the trigger is called, run the LoadMaze() function
        if (loadGame.loadMe == true) {
            LoadMaze();
        }
    }

    public void LoadMaze() {
        //Load the Menu Scene
       StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel() {
        //Wait for the fade-out animation to play before loading the scene.
        anim.Play("OnLoadOut");

        yield return new WaitForSeconds(2);

        SceneManager.LoadScene("menuScene");
    }
}
