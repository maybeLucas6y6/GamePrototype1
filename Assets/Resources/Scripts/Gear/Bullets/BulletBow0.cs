using UnityEngine;

public class BulletBow0 : MonoBehaviour
{
    public Rigidbody2D rb;

    public int damage = 1;
    public float speed = 10f;
    public float lifetime = 0.5f;

    public void UpdateVars(int dmg, float spd, float lft)
    {
        damage = dmg;
        speed = spd;
        lifetime = lft;
    }

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + speed * Time.deltaTime * transform.up);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyBasicStats>().healthPoints -= damage;
        }
    }
}
