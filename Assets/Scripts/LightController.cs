using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{

    private Rigidbody2D rigid;
    private Vector2 velocity;
    private Vector2 curPos;
    [SerializeField]
    private float moveVel;
    private float xAxis;
    private float yAxis;
    private float magnitude;

    // Start is called before the first frame update
    void Start()
    {
        magnitude = 5;
        velocity = Vector2.zero;
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update() 
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        yAxis = Input.GetAxisRaw("Vertical");
        curPos += new Vector2(xAxis, yAxis) * moveVel;
        Vector3 cameraPos = Camera.main.transform.position;
        curPos = new Vector2(Mathf.Clamp(curPos.x, cameraPos.x - 8, cameraPos.x + 8),
                             Mathf.Clamp(curPos.y, cameraPos.y - 4, cameraPos.y + 4));
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
