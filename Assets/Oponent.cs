using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oponent : MonoBehaviour
{
    public float speed;
    public Transform player;
    public float minimumDistance;
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > minimumDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position,player.position,speed*Time.deltaTime);
        }
        else
        {
            // attack code
        }
    }
}
