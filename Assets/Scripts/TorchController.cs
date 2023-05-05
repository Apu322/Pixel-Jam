using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchController : MonoBehaviour
{

    [SerializeField]
    private float torchCooldown;

    [SerializeField]
    private float turnDownStart;

    [SerializeField]
    private string lightType;

    private Animator anim;
    private float timePassedLit;

    private UnityEngine.Rendering.Universal.Light2D light;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play(lightType + "_unlit");
        light = transform.GetChild(0).GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        light.enabled = false;        

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        light.enabled = true;
        //col.transform.parent.GetComponent<LightController>().intensity -= 0.25f;
        anim.Play(lightType + "_lit");
        light.intensity = 1;
        timePassedLit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timePassedLit > torchCooldown)
        {
            light.enabled = false;
            anim.Play(lightType + "_unlit");
            timePassedLit = 0;
        }
        else if (light.enabled && timePassedLit > turnDownStart)
        { 
            light.intensity = Mathf.Lerp(1, 0, timePassedLit / torchCooldown);
        }
        timePassedLit += Time.deltaTime;
    }
}
