using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortraitController : MonoBehaviour
{
    private Image background;

    private Color startColor;

    private void Start()
    {
        background = transform.GetChild(0).GetComponent<Image>();
        startColor = background.color;
    }
    void OnMouseOver()
    {
        background.color = Color.red;
    }

    void OnMouseExit()
    {
        background.color = startColor;
    } 
}
