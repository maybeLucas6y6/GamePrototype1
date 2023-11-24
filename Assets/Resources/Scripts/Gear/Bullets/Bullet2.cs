using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    public Rigidbody2D rb;

    public float speed = 5f;
    public float lifetime = 0.5f;

    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(transform.position + speed * Time.deltaTime * transform.up);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerStats>().healthPoints -= damage;
        }
    }
}
