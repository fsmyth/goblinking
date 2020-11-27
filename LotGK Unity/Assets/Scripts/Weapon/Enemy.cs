
using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float health = 3f;
    public Animator anim;
    public UnityEngine.AI.NavMeshAgent enemy;
    public GameObject player;
    public GameObject hurtholder;
    public AudioSource clip;
    public AudioSource hit;

    void start () {
        anim = GetComponent<Animator>();
        enemy = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GetComponent<GameObject>();
        hurtholder = GetComponent<GameObject>();
        clip = hurtholder.GetComponent<AudioSource>();
        hit = GetComponent<AudioSource>();
    }

    public void HurtEnemy(float amount) { //When the enemy is hit, play the animation & sound clip, and remove health equal to the damage dealt.
                                          //If the enemy loses its last hp, run the death function.
        
        hit.Play();
        if (health > 1f) {
        anim.Play("combat_get_hit", 0, 0);
        health -= amount; }
        else Die();
        
    }

    void Die() { //Play the death animation and sound, then disable the object.
        anim.Play("combat_death", 0, 0);
        clip.Play();
            StartCoroutine(kill_enemy());
        
    }

    IEnumerator kill_enemy() { //Wait until the death animation is finished, then disable the object.
            yield return new WaitForSeconds(1f); 
            gameObject.SetActive(false);
        
        }

}
