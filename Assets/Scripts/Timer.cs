using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public float timeRemaining;
    public bool timerIsRunning = false;
    public Text timeText;

    // Reference to FMOD Studio Event Emitter component on the same GameObject
    private FMODUnity.StudioEventEmitter eventEmitter;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;

        // Get the reference to the FMOD Studio Event Emitter component
        eventEmitter = GetComponent<FMODUnity.StudioEventEmitter>();
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);


                if (timeRemaining >=0 && timeRemaining <=29.9999)
                {
                    eventEmitter.SetParameter("timer", 4.0f);
                    

                }
                else if (timeRemaining >=30 && timeRemaining <=119.9999)
                {
                    eventEmitter.SetParameter("timer", 3.0f);
                }

                else if (timeRemaining >=120 && timeRemaining <=209.9999)
                {
                    eventEmitter.SetParameter("timer", 2.0f);
                }
		
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                eventEmitter.SetParameter("game_status", 2.0f);
                timerIsRunning = false;
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
