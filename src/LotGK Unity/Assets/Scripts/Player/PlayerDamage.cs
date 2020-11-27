using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
    //Sets default health to 5
    public int maxHealth = 5;
    public int health;
    public HealthBar healthBar;
    public GameObject hurtholder;
    public AudioSource clip;

    private void Start()
    {
        health = maxHealth;
        hurtholder = GetComponent<GameObject>();
        clip = hurtholder.GetComponent<AudioSource>();
    }

    void Update() {
        // if (Input.GetKeyDown(KeyCode.Space)) { //Testing damage, press spacebar to deal one damage to the player.
        //     DealDamage(1);
        // }
    }

    void DealDamage(int damage)
    {
        //If you have more HP, lose HP. Otherwise, the game ends.
        if (health > 1)
        {
            //Stores the current health and subtracts the damage value
            health -= damage;
            clip.Play(); //Play hurt sound
        } else {
            SceneManager.LoadScene("gameOver"); //If player runs out of HP, the game ends.
        }
        healthBar.SetHealth(health);
    }

}
