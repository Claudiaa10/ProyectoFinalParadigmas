using UnityEngine;

public class Oponent : MonoBehaviour
{
    public float speed;
    public Transform player;
    public float minimumDistance;
    private void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > minimumDistance)
        {
            MoveTowardsPlayer();
        }
        else
        {
            Attack();
        }
    }

    private void MoveTowardsPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    private void Attack()
    {
        Debug.Log("Oponente ataca al jugador.");
        EventManager.OnPlayerAttacked();
    }
}
