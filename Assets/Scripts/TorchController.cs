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
    private LightController mainLight;

    private float timePassedNormal;

    [SerializeField]
    private float maxIntensity;

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
        if (light.enabled || mainLight.GetCount() == 0)
            return;
        light.enabled = true;
        mainLight.DecreaseCount();
        anim.Play(lightType + "_lit");
        light.intensity = maxIntensity;
        timePassedLit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (light.enabled)
        {
            if (timePassedLit > torchCooldown)
            {
                light.enabled = false;
                anim.Play(lightType + "_unlit");
                mainLight.IncreaseCount();
                timePassedLit = 0;
            }
            else if (timePassedLit > turnDownStart)
            { 
                light.intensity = Mathf.Lerp(maxIntensity, 0, timePassedLit / torchCooldown);
            }
            timePassedLit += Time.deltaTime;

        }
    }
}
