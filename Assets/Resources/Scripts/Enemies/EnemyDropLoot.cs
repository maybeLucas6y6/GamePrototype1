using System;
using UnityEngine;

public class EnemyDropLoot : MonoBehaviour
{
    [SerializeField] private GameObject lootBag;
    [SerializeField] private float dropRate;
    [SerializeField] private Loot[] lootTable;

    public void DropLoot()
    {
        if (UnityEngine.Random.Range(0f, 100f) <= dropRate)
        {
            var bag = Instantiate(lootBag, transform.position, Quaternion.identity);
            bag.GetComponent<ShowLootbag>().SetLoot(lootTable);
        }
    }
}

[Serializable] public struct Loot
{
    public InventoryItemData data;
    public int amount;
}