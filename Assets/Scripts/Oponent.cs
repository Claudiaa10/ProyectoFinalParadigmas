using UnityEngine;

public class Oponent : MonoBehaviour
{
    public float speed;
    public Transform player;
    public float minimumDistance;
    public bool isGameOver;

    private void Start()
    {
        isGameOver = false;
    }
    private void Update()
    {
        if (!isGameOver)
        {
            if (Vector2.Distance(transform.position, player.position) > minimumDistance)
            {
                MoveTowardsPlayer();
            }
            else
            {
                Debug.Log("ataca");
                Attack();
            }
        }
    }

    private void MoveTowardsPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    private void Attack()
    {
        Debug.Log("Oponente ataca al jugador.");
        isGameOver = true;
        EventManager.OnPlayerAttacked();
    }
}
