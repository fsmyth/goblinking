using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5;

    // public float jumpPower = 4;

    Rigidbody rb;

    CapsuleCollider col;
    public GameObject gM;
    public GoblinManager gobMan;
    public AudioSource clip;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        gM = GetComponent<GameObject>();
        gobMan = gM.GetComponent<GoblinManager>();
        clip = GetComponent<AudioSource>();
    }

    void Update()
    {   //When the A and D keys are pressed, move horizontally to the player's position, and when the W and S keys are pressed, move vertically to the player's position.
        float Horizontal = Input.GetAxis("Horizontal") * speed;
        float Vertical = Input.GetAxis("Vertical") * speed;
        Horizontal *= Time.deltaTime;
        Vertical *= Time.deltaTime;

        transform.Translate(Horizontal, 0, Vertical);

        // if(Input.GetButtonDown("Jump")) {
            
        //         gobMan.ApplyScore(50); //Debugging... This adds 50 score to the HUD score counter when the spacebar is pressed.
        // }

        if(Input.GetKeyDown("escape")) { //When the ESC key is pressed, shut down the game.
            QuitGame();
        }
    }

    public void OnTriggerEnter(Collider other) { //When the player collides with anything tagged as "Treasure", play the attached sound clip, 
                                                 //add 25 score to the score manager and destroy the collectible object.
        if (other.tag == "Treasure") {
                clip.Play();
                gobMan.ApplyScore(25);
                Destroy(other.gameObject);
        }
    }
    
    public void QuitGame()
 {
     #if UNITY_EDITOR   //Quit the Unity Editor
         UnityEditor.EditorApplication.isPlaying = false;
     #else              //Quit the exported application
         Application.Quit();
     #endif
 }

    // private bool isGrounded() {
    //     //we are drawing an invisible line from object to floor
    //     return Physics.Raycast(transform.position, Vector3.down, col.bounds.extents.y + 0.1f);
    // }
}
