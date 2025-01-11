/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliceMovement : MonoBehaviour
{
    public Rigidbody2D body;

    // Variables para movimiento
    public float groundSpeed;
    public float jumpSpeed;
    public bool grounded;
    [Range(0f, 1f)]
    public float groundDecay;
    public BoxCollider2D groundCheck;
    public LayerMask groundMask;

    public float verticalMove;

    void Start()
    {
        // Inicializaciones si es necesario
    }

    void Update()
    {
        GetInput();
        MoveWithInput();
    }

    void MoveWithInput()
    {
        // Movimiento vertical (saltar)
        if (Mathf.Abs(verticalMove) > 0 && grounded)
        {
            body.velocity = new Vector2(body.velocity.x, verticalMove * jumpSpeed);
        }
    }

    void GetInput()
    {
        // Solo capturamos el eje vertical
        verticalMove = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        CheckGround();
        ApplyFriction();
    }

    void CheckGround()
    {
        // Verificar si el personaje est� en el suelo
        grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max).Length > 0;
    }

    void ApplyFriction()
    {
        // Aplicar fricci�n si est� en el suelo y no se mueve
        if (grounded && verticalMove == 0)
        {
            body.velocity = new Vector2(body.velocity.x, body.velocity.y * groundDecay);
        }
    }
}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliceMovement : MonoBehaviour
{
    public Rigidbody2D body;

    // Variables para movimiento
    public float groundSpeed;
    public float jumpSpeed;
    public bool grounded;
    [Range(0f, 1f)]
    public float groundDecay;
    public BoxCollider2D groundCheck;
    public LayerMask groundMask;

    public float horizontalMove;
    public float verticalMove;

    void Update()
    {
        GetInput();
        MoveWithInput();
    }

    void GetInput()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
    }

    void MoveWithInput()
    {
        // Aplicar movimiento horizontal
        body.velocity = new Vector2(horizontalMove * groundSpeed, body.velocity.y);

        // Movimiento vertical (saltar)
        if (Mathf.Abs(verticalMove) > 0 && grounded)
        {
            body.velocity = new Vector2(body.velocity.x, verticalMove * jumpSpeed);
        }
    }

    private void FixedUpdate()
    {
        CheckGround();
        ApplyFriction();
    }

    void CheckGround()
    {
        grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0;
    }

    void ApplyFriction()
    {
        if (grounded && horizontalMove == 0)
        {
            body.velocity = new Vector2(0, body.velocity.y * groundDecay);
        }
    }
}

