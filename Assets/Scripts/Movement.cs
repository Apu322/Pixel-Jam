using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Animator anim;

    private Rigidbody2D rigid;

    [SerializeField]
    private float walkSpeed = 5f;

    private float xAxis;
    private float yAxis;

    private string currentAnim;

    const string PLAYER_WALK_0_0 = "Walk_0_0";
    const string PLAYER_WALK_0_1 = "Walk_0_0";
    const string PLAYER_WALK_0_2 = "Walk_0_0";
    const string PLAYER_WALK_1_0 = "Walk_1_0";
    const string PLAYER_WALK_1_1 = "Walk_1_0";
    const string PLAYER_WALK_1_2 = "Walk_1_0";
    const string PLAYER_WALK_2_0 = "Walk_2_0";
    const string PLAYER_WALK_2_1 = "Walk_2_0";
    const string PLAYER_WALK_2_2 = "Walk_2_0";
    const string PLAYER_IDLE_0_0 = "Idle_0_0";
    const string PLAYER_IDLE_0_1 = "Idle_0_0";
    const string PLAYER_IDLE_0_2 = "Idle_0_0";
    const string PLAYER_IDLE_1_0 = "Idle_1_0";
    const string PLAYER_IDLE_1_1 = "Idle_1_0";
    const string PLAYER_IDLE_1_2 = "Idle_1_0";
    const string PLAYER_IDLE_2_0 = "Idle_2_0";
    const string PLAYER_IDLE_2_1 = "Idle_2_0";
    const string PLAYER_IDLE_2_2 = "Idle_2_0";

    private string[,,] anims;
    private int currentX;
    private int currentY;
    private string stance;

    private int framesSkipped;
    private int framesToSkip;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); 
        rigid = GetComponent<Rigidbody2D>();
        framesToSkip = 1;
    }                               

    // Update is called once per frame
    void Update()
    {
        framesSkipped += 1;
        if (framesSkipped > framesToSkip)
        {
            xAxis = Input.GetAxisRaw("Horizontal");
            yAxis = Input.GetAxisRaw("Vertical");
            framesSkipped = 0;
        }
    }

    private void FixedUpdate()
    {
        Vector2 vel = new Vector2(xAxis * walkSpeed, yAxis * walkSpeed);
        rigid.velocity = vel;
        if (xAxis != 0 || yAxis != 0)
        {
            stance = "Walk";
            currentX = (int) xAxis + 1;
            currentY = (int) yAxis + 1;
        }
        else
        {
            stance = "Idle";
        }
        Debug.Log("x: " + currentX + ", y: " + currentY);
        ChangeAnimationState(stance + "_" + currentX + "_" + currentY);
    }

    private void ChangeAnimationState(string newAnimation)
    {
        if (currentAnim == newAnimation)
        {
            return;
        }

        anim.Play(newAnimation);
        currentAnim = newAnimation;
    }
}
