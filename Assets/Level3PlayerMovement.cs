using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3PlayerMovement : MonoBehaviour
{
    public float speed;
    public float speedX;
    public float speedY;
    public Rigidbody2D player;
    public bool facingRight;
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal") * speed;
        speedY = Input.GetAxisRaw("Vertical") * speed;
        player.velocity = new Vector2 (speedX, speedY);

        if (speedX > 0 && !facingRight)
        {
            Flip();
        }
        else if (speedX < 0 && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1; 
        transform.localScale = scale;
    }
}
