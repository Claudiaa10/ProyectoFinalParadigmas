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
        // Verificar si el personaje está en el suelo
        grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max).Length > 0;
    }

    void ApplyFriction()
    {
        // Aplicar fricción si está en el suelo y no se mueve
        if (grounded && verticalMove == 0)
        {
            body.velocity = new Vector2(body.velocity.x, body.velocity.y * groundDecay);
        }
    }
}
