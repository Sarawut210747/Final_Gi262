using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float Speed = 10f;
    public int damage = 10;

    private Transform target;

    public void Setup(Transform t)
    {
        target = t;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) { Destroy(gameObject); return; }

        transform.position = Vector2.MoveTowards(
            transform.position,
            target.position,
            Speed * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            target.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
