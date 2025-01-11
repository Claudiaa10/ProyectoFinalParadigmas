using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce; 
    public Vector2 boxSize;
    public float verticalMove;
    public float castDistance; 
    public LayerMask groundLayer;

    private Rigidbody2D body; 
    private bool grounded;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Actualiza el estado de grounded.
        grounded = IsGrounded();

        verticalMove = Input.GetAxis("Vertical");
        if (verticalMove > 0 && grounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpForce);
    }

    public bool IsGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
