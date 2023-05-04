using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchController : MonoBehaviour
{

    [SerializeField]
    private float torchCooldown;

    private float timePassedLit;

    private UnityEngine.Rendering.Universal.Light2D light;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        light.enabled = false;        

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        light.enabled = true;
        timePassedLit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timePassedLit > torchCooldown)
        {
            light.enabled = false;
            timePassedLit = 0;
        }
        else if (light.enabled)
        { 
            light.intensity = Mathf.Lerp(1, 0, timePassedLit / torchCooldown);
        }
        timePassedLit += Time.deltaTime;
    }
}
