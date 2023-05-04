using UnityEngine;
using FMODUnity;

public class player_starts_game : MonoBehaviour
{
    [SerializeField]
    private StudioEventEmitter fmodEmitter;

    [SerializeField]
    private string parameterName = "game_status";

    private float parameterValue = 1f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fmodEmitter.SetParameter(parameterName, parameterValue);
        }
    }
}

