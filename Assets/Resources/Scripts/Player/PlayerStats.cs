using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealthPoints;
    public int healthPoints;
    public bool canRegenerateHP = true;
    private int passiveHPRegenerationAmount = 1;
    private float passiveHPRegenerationRate = 1f;
    private HPBar healthBar;

    private void Start()
    {
        healthBar = transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<HPBar>();
        healthPoints = maxHealthPoints;
        healthBar.SetMaxHealth(maxHealthPoints);
        healthBar.SetHealth(healthPoints);
        StartCoroutine(PassiveRegeneration());
    }

    private void Update()
    {
        healthBar.SetMaxHealth(maxHealthPoints);
        healthBar.SetHealth(healthPoints);
        if (healthPoints <= 0)
        {
            Camera cam = Camera.main;
            cam.transform.SetParent(null, true);
            Destroy(gameObject);
        }
    }

    private IEnumerator PassiveRegeneration()
    {
        while (canRegenerateHP) 
        {
            if (healthPoints < maxHealthPoints) {
                healthPoints += passiveHPRegenerationAmount;
                yield return new WaitForSeconds(passiveHPRegenerationRate);
            } 
            else
            {
                yield return null;
            }
        }
    } 
}
