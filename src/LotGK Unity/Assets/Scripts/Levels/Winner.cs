using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Winner : MonoBehaviour
{
    public Animator anim;

    //When this scene starts, play the jump animation
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        anim.Play("normal_jump");
    }
}
