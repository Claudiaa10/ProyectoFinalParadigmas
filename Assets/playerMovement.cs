using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class playerMovement : MonoBehaviour
   
{
    public Rigidbody2D body;
    // Start is called before the first frame update
    public float groundSpeed;
    public float jumpSpeed;
    public bool grounded;
    [Range(0f, 1f)]
    public float groundDecay;
    public BoxCollider2D groundCheck;
    public LayerMask groundMask;

    public float horizontalMove;
    public float verticalMove;


    // Update is called once per frame

   void Start()
    {
        
    }
    void Update()
    {

        GetInput();
        MoveWithInput();
    }

    void MoveWithInput()
    {
        Vector2 vector2 = new Vector2(horizontalMove, verticalMove);
        if (Mathf.Abs(horizontalMove) > 0)
        {
            body.velocity = new Vector2(horizontalMove * groundSpeed, body.velocity.y);
            float direction = Mathf.Sign(horizontalMove);
            transform.localScale = new Vector3(direction, 1, 1);
        }
        if (Mathf.Abs(verticalMove) > 0 && grounded)
        {
            body.velocity = new Vector2(body.velocity.x, verticalMove * jumpSpeed);

        }
    }
    void GetInput()
    {
       horizontalMove = Input.GetAxis("Horizontal");
       verticalMove = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
        CheckGround();
        ApplyFriction();
    }

    void CheckGround()
    {
        grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max).Length >0;
    }

    void ApplyFriction()
    {

        if (grounded && horizontalMove == 0 && verticalMove == 0)
        {
            body.velocity *= groundDecay;
        }
    }
}
