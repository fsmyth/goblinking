using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10;
    public Text timeText;
    public bool timerIsRunning = false;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }

    void Update()
    {
        //While the timer has time left, count it down one second at a time.
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                //End the game when the timer runs out
                SceneManager.LoadScene("gameOver");
            }

            DisplayTime(timeRemaining);
        }
        //Show the time on the HUD Timer
    void DisplayTime(float timeToDisplay)
{
    //Divide the time into minutes, and take the remainder as seconds.
  float minutes = Mathf.FloorToInt(timeToDisplay / 60);  
  float seconds = Mathf.FloorToInt(timeToDisplay % 60);

//Send the result to the HUD in digital clock format.
  timeText.text = "Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);
}
    }
}