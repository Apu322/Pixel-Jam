using UnityEngine;
using FMODUnity;

public class FootstepPlayer : MonoBehaviour
{
    // The FMOD event to play
    public EventReference footstepsEvent;

    // The FMOD event instance
    private FMOD.Studio.EventInstance footstepsInstance;

    // The time at which the last footsteps were played
    private float lastFootstepTime;

    // The interval in seconds at which the footsteps should be played
    private float footstepInterval = 0.15f;

    void Start()
    {
        // Create an instance of the FMOD event
        footstepsInstance = RuntimeManager.CreateInstance(footstepsEvent);
    }

    void Update()
    {
        // Check if any of the WASD keys are pressed
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            // Check if the interval time has elapsed since the last footsteps were played
            if (Time.time - lastFootstepTime >= footstepInterval)
            {
                // Play the FMOD event
                footstepsInstance.start();
                // Update the lastFootstepTime to the current time
                lastFootstepTime = Time.time;
            }
        }
    }

    void OnDestroy()
    {
        // Release the FMOD event instance when the script is destroyed
        footstepsInstance.release();
    }
}
