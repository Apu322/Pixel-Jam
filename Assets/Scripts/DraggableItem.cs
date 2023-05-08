
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    private Vector2 initialPos;
    private Vector3 initialRotation;
    private bool isDragging;
    private float rotationSpeed;

    [SerializeField]
    private GameObject pair;

    [SerializeField]
    private GameObject grabPoint;

    private Vector3 diff;

    private void Start() 
    {
        initialPos = transform.localPosition;
        initialRotation = transform.eulerAngles;
        rotationSpeed = 200;
        isDragging = false;
        transform.localPosition = new Vector2(Random.Range(-250, 250), Random.Range(-120, 120));   
        transform.localEulerAngles = new Vector3(0, 0, Random.Range(0, 360)); 
    }

    private void Update() 
    {
        if (isDragging)
        {
            if (Input.GetKey(KeyCode.E))
            {
                transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z + rotationSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.Q))
            {
                transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z - rotationSpeed * Time.deltaTime);
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if ((Input.mousePosition - grabPoint.transform.position).magnitude < 50)
        {
            diff = transform.position - Input.mousePosition;
            isDragging = true;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            transform.position = diff + Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            if (pair != null)
            {
                Vector3 rotation = transform.eulerAngles;
                float posMag = (pair.transform.localPosition - new Vector3(transform.localPosition.x, transform.localPosition.y)).magnitude;
                float rotMag = (pair.transform.localEulerAngles - rotation).magnitude;
                Debug.Log("pos: " + posMag);
                Debug.Log("rotMag: " + rotMag); 
                if (posMag < 5 && rotMag < 5)
                {
                    GetComponent<Image>().color = Color.red;
                    transform.GetComponent<DraggableItem>().enabled = false;
                    pair.GetComponent<Image>().color = Color.red;
                    pair.transform.GetComponent<DraggableItem>().enabled = false;
                }
            }
            isDragging = false;

        }
    }
}