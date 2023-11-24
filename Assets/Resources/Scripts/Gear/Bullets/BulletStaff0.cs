using UnityEngine;

public class BulletStaff0 : MonoBehaviour
{
    public Rigidbody2D rb;

    public int damage = 1;
    public float speed = 15f;
    public float lifetime = 0.8f;

    private float spawnTime;
    private int sign;
    private float magnitude = 0.05f;
    private float frequency = 17f;

    public void UpdateVars(int dmg, float spd, float lft)
    {
        damage = dmg;
        speed = spd;
        lifetime = lft;
    }

    public void SetSign(int s)
    {
        sign = s;
    }

    void Start()
    {
        Destroy(gameObject, lifetime);
        spawnTime = Time.time;
    }

    void Update()
    {
        transform.position += speed * Time.deltaTime * transform.up;
        transform.position += magnitude * Mathf.Cos((Time.time - spawnTime) * frequency) * sign * transform.right;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyBasicStats>().healthPoints -= damage;
            Destroy(gameObject);
        }
    }
}
