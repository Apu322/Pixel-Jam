using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    private Vector2 initialPos;
    private Vector3 initialRotation;
    private bool isDragging;
    private float rotationSpeed;

    private void Start() 
    {
        initialPos = transform.localPosition;
        initialRotation = transform.eulerAngles;
        rotationSpeed = 100;
        isDragging = false;
        transform.localPosition = new Vector2(Random.Range(-600, 300), Random.Range(-10, 40));   
        transform.Rotate(new Vector3(0, 0, Random.Range(0, 360))); 
    }

    private void Update() 
    {

        if (isDragging && Input.GetKey(KeyCode.R))
        {
         //   Debug.Log("asdf");
            transform.Rotate(new Vector3(0, 0, transform.rotation.z + rotationSpeed * Time.deltaTime));
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        isDragging = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Vector3 rotation = transform.eulerAngles;
        float posMag = (initialPos - new Vector2(transform.localPosition.x, transform.localPosition.y)).magnitude;
        float rotMag = (initialRotation - rotation).magnitude;
        Debug.Log("pos: " + posMag);
        Debug.Log("rotMag: " + rotMag); 
        if (posMag < 15 && rotMag < 5)
        {
            transform.localPosition = initialPos;
            Debug.Log("asdf");
            GetComponent<DraggableItem>().enabled = false;
        }
        isDragging = false;
    }
}
