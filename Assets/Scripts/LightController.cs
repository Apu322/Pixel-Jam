using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{

    private Rigidbody2D rigid;
    private Vector2 velocity;
    [SerializeField]
    private float forceMag;

    [SerializeField]
    private float frictionMag;
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
        Vector3 cameraPos = Camera.main.transform.position;
        Vector2 clampedPos = new Vector2(Mathf.Clamp(transform.position.x, cameraPos.x - 8, cameraPos.x + 8),
                             Mathf.Clamp(transform.position.y, cameraPos.y - 4, cameraPos.y + 4));
        transform.position = clampedPos;
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        Vector2 force = new Vector2(xAxis, yAxis);
        force = force * forceMag;
        Vector2 frictionForce = -rigid.velocity.normalized;
        frictionForce = frictionForce * frictionMag;
        rigid.velocity = rigid.velocity + force + frictionForce;
    }
}
