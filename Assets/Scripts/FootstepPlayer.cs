using UnityEngine;
using FMODUnity;

public class FootstepPlayer : MonoBehaviour
{
    // The FMOD event to play
    public EventReference footstepsEvent;

    // The FMOD event instance
    private FMOD.Studio.EventInstance footstepsInstance;

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
            // Play the FMOD event
            footstepsInstance.start();
        }
    }

    void OnDestroy()
    {
        // Release the FMOD event instance when the script is destroyed
        footstepsInstance.release();
    }
}


