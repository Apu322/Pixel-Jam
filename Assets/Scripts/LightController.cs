using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{

    private Rigidbody2D rigid;
    private Vector2 velocity;
    private Vector2 curPos;
    private float moveVel;
    private float xAxis;
    private float yAxis;
    private float magnitude;

    // Start is called before the first frame update
    void Start()
    {
        magnitude = 5;
        moveVel = 0.5f;
        velocity = Vector2.zero;
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update() 
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        yAxis = Input.GetAxisRaw("Vertical");
        curPos += new Vector2(xAxis, yAxis) * moveVel;
        curPos = new Vector2(Mathf.Clamp(curPos.x, curPos.x - 8, curPos.x + 10),
                             Mathf.Clamp(curPos.y, curPos.y - 6, curPos.y + 4));
    }
    // Update is called once per frame
    void FixedUpdate()
    {

      //  Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      //  worldPosition.z = 0;

      //  Vector3 relative = transform.position - worldPosition;
      //  float distance = relative.magnitude;
      //  Vector3 direction = relative.normalized;
        transform.position = Vector2.SmoothDamp(transform.position, curPos, ref velocity, 0.3f);
    }
}
