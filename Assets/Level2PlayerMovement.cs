/*
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

    void Update()
    {
        Debug.Log(Time.timeScale);
        speedX = Input.GetAxisRaw("Horizontal") * speed;
        speedY = Input.GetAxisRaw("Vertical") * speed;
        Debug.Log($"speedX: {speedX}, speedY: {speedY}");

        player.velocity = new Vector2(speedX, speedY);
        Debug.Log(player.velocity);

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
*/