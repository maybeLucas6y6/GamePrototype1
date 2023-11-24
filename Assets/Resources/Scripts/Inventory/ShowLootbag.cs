using System.Collections.Generic;
using UnityEngine;

public class ShowLootbag : MonoBehaviour
{
    [SerializeField] private List<ItemObject> loot;
    [SerializeField] private Loot[] droppedLoot;
    private bool loaded = false;

    private void Start()
    {
        Destroy(gameObject, 30f);
    }

    public void SetLoot(Loot[] lootTable)
    {
        droppedLoot = lootTable;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!loaded)
            {
                LootInventory.instance.OnUpdateInventory(droppedLoot);
                loaded = true;
            }
            else
            {
                LootInventory.instance.OnUpdateInventory(loot);
            }
            LootInventory.instance.lootInventory.SetActive(true);
            LootInventory.instance.currentLootbag = gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Invoke(nameof(Clear), 0.01f);
        }
    }

    public void UpdateInventory()
    {
        List<ItemObject> sameItems = new();
        foreach (Transform t in LootInventory.instance.lootInventory.transform)
        {
            if (t.childCount > 0)
            {
                sameItems.Add(t.GetChild(0).gameObject.GetComponent<ItemObject>());
            }
        }
        if (sameItems.Count == 0)
        {
            Destroy(gameObject);
        }
        loot = sameItems;
        LootInventory.instance.OnUpdateInventory(loot);
    }

    private void OnDestroy()
    {
        Clear();
    }

    private void Clear()
    {
        if (LootInventory.instance.holdItem != null)
        {
            Destroy(LootInventory.instance.holdItem);
            LootInventory.instance.holdItem = null;
        }
        LootInventory.instance.currentLootbag = null;
        LootInventory.instance.Clear();
        LootInventory.instance.lootInventory.SetActive(false);
    }
}