using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This class holds the enemy object, allowing it to be placed in an array.
public class Goblin
{
    public GameObject go;
    public bool active;
    public Goblin(GameObject newGo, bool newBool)
    {
        go = newGo;
        active = newBool;
    }
}

public class GoblinManager : MonoBehaviour
{
    public GameObject spawn;
    public Text scorePanel;
    public int score = 0;
    public int amount = 1;
    public float delaySpawn = 1;
    public bool spawnsDead;

    private int getAmount;
    private float timer;
    private int spawned;
    private int enemyDead;
     private int x;
     private int y;
     private int z;
     private Vector3 pos;

    public List<Goblin> enemies = new List<Goblin>();

    public void Start()
    {
        ApplyScore(0);
        ResetRound();
        while (spawned < getAmount)
        {
            //Increment the amount spawned count.
            spawned++;
            //Spawn the enemies somewhere within the maze
            x = UnityEngine.Random.Range(-5, 4);
            y = 3;
            z = UnityEngine.Random.Range(-5, 4);
            pos = new Vector3(x, y, z);
            //Create the prefab as an instance.
            GameObject instance = Instantiate(spawn, pos, transform.rotation);
            enemies.Add(new Goblin(instance, false));
            //Removes the spawned object from the spawner object.
            instance.transform.parent = null;
            instance.SetActive(false);
        }
        ResetRound();
    }
    //Reset the spawner
    public void ResetRound()
    {
        spawnsDead = false;
        getAmount = amount;
        spawned = 0;
        timer = 0;
        enemyDead = 0;
    }

    void Update()
    {
        //Increase timer per frame.
        timer += Time.deltaTime;
        //Do the spawn if our timer is larger than the delay spawn we set.
        if (delaySpawn < timer)
        {
            //And we haven’t reached the spawn amount.
            if (spawned < getAmount)
            {
                //Reset our timer.
                timer = 0;
                //Set our bool to track the state of the enemy.
                enemies[spawned].active = true;
                //Set the enemy to be active.
                enemies[spawned].go.SetActive(true);
                //Increment the amount spawned count.
                spawned++;
            }

            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                //If another script disabled the object but we set them active above.
                if (enemies[i].go.activeSelf == false && enemies[i].active == true)
                {
                    //Reset the spawn position and set our tracking bool that they are not active.
                    enemies[i].go.transform.position = transform.position;
                    enemies[i].active = false;
                    enemyDead++;
                    ApplyScore(10);
                }
            }

            if (enemyDead == enemies.Count)
            {
                spawnsDead = true;
            }
        }
    }

    private void OnDrawGizmos()
    {
        //Draw the wireframe mesh of what we intend to spawn in our editor.
        Gizmos.color = Color.red;
        if (spawn != null)
        {
            Gizmos.DrawWireMesh(spawn.GetComponent<MeshFilter>().sharedMesh, transform.position, spawn.transform.rotation, Vector3.one);
        }
    }

    public void ApplyScore(int addedScore)
    {
        //If we have a score panel, add score equal to the amount given
        if (scorePanel != null)
        {
            
            //Adds new value to the current score
            score = score + addedScore;
            // Debug.Log(score);
            //Display score to screen
            scorePanel.text = "Score: " + score.ToString();
        }
    }
}