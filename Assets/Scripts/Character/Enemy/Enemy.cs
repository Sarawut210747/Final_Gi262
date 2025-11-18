using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 50;
    private int currentHP;

    private Transform player;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHP = hp;
    }

    void Update()
    {
        if (player == null) return;
    }

    public void TakeDamage(int dmg)
    {
        currentHP -= dmg;
        if (currentHP <= 0)
        {
            Die();
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<PlayerStats>().TakeDamage(10);
        }
    }
    void Die()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        playerObj.GetComponent<PlayerStats>().OnEnemyKilled();

        Destroy(gameObject);
    }
}
