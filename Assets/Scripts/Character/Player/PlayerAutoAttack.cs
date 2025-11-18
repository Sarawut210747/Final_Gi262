using UnityEngine;
using System.Collections.Generic;

public class PlayerAutoAttack : MonoBehaviour
{
    public float attackRange = 5f;
    public float fireRate = 1f;
    public GameObject bulletPrefab;

    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Enemy target = FindClosestEnemy();

            if (target != null)
            {
                Shoot(target.transform);
                timer = fireRate;
            }
        }
    }

    Enemy FindClosestEnemy()
    {
        Enemy[] enemies = GameObject.FindObjectsByType<Enemy>(FindObjectsSortMode.None);

        Enemy closest = null;
        float minDist = Mathf.Infinity;

        foreach (Enemy e in enemies)
        {
            float dist = Vector2.Distance(transform.position, e.transform.position);

            if (dist < minDist && dist <= attackRange)
            {
                minDist = dist;
                closest = e;
            }
        }
        return closest;
    }

    void Shoot(Transform target)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<PlayerBullet>().Setup(target);
    }
}
