using UnityEngine;

public class RingHP0 : MonoBehaviour
{
    private PlayerStats playerStats;
    [SerializeField] private int bonusHP = 10;

    void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    private void Start()
    {
        playerStats.maxHealthPoints += bonusHP;
    }

    private void OnDestroy()
    {
        playerStats.maxHealthPoints -= bonusHP;
        if(playerStats.maxHealthPoints < playerStats.healthPoints)
        {
            playerStats.healthPoints = playerStats.maxHealthPoints;
        }
    }
}
