using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField]
    private float flickSpeed;

    [SerializeField]
    private GameController gameManager;

    private float timePassed;

    private UnityEngine.Rendering.Universal.Light2D light;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += flickSpeed * Time.deltaTime;
        light.intensity = (1 + Mathf.Sin(timePassed)) / 2;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        gameObject.SetActive(false);
        gameManager.FragCollected();
    }
}
