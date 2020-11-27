using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    //When the player touches the portal, send them to the victory screen
    void OnTriggerEnter(Collider other) {
        if(other.transform.CompareTag("Player")) {
            Cursor.visible = true;
            SceneManager.LoadScene("winScene");
        }
    }
}
