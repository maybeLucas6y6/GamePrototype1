using UnityEngine;

public class EnemyBasicStats : MonoBehaviour
{
    public int maxHealthPoints;
    [HideInInspector] public int healthPoints;
    private HPBar healthBar;

    public int touchDamage;

    private void Start()
    {
        healthBar = transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<HPBar>();
        healthPoints = maxHealthPoints;
        healthBar.SetMaxHealth(maxHealthPoints);
        healthBar.SetHealth(healthPoints);
    }

    private void Update()
    {
        healthBar.SetHealth(healthPoints);
        if(healthPoints <= 0)
        {
            if(TryGetComponent(out EnemyDropLoot dropLoot))
            {
                dropLoot.DropLoot();
            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerStats>().healthPoints -= touchDamage;
        }
    }
}
