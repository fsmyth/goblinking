using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillMe : MonoBehaviour
{
    public Animator anim;
    //Play the death animation at the start of the scene
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        anim.Play("combat_death");
    }
}
