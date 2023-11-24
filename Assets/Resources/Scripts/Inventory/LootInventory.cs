using System.Collections.Generic;
using UnityEngine;

public class LootInventory : MonoBehaviour
{
    [HideInInspector] public GameObject holdItem;
    [HideInInspector] public GameObject currentLootbag;

    public static LootInventory instance;
    [SerializeField] private GameObject slot;
    public GameObject lootInventory;

    private void Start()
    {
        instance = this;
    }

    public void OnUpdateInventory(List<ItemObject> newItems)
    {
        Clear();
        foreach (ItemObject item in newItems)
        {
            var newSlot = Instantiate(slot);
            newSlot.transform.SetParent(lootInventory.transform, false);
            var newItemSlot = newSlot.transform.GetChild(0);
            newItemSlot.GetComponent<ItemObject>().referenceItem = item.referenceItem;
            newItemSlot.GetComponent<ItemObject>().amount = item.amount;
            newItemSlot.GetComponent<DragAndDropItem>().SetCanvas(lootInventory);
            newItemSlot.GetComponent<Slot>().Set(item);
        }
    }

    public void OnUpdateInventory(Loot[] newItems)
    {
        Clear();
        foreach (Loot item in newItems)
        {
            var newSlot = Instantiate(slot);
            newSlot.transform.SetParent(lootInventory.transform, false);
            var newItemSlot = newSlot.transform.GetChild(0);
            newItemSlot.GetComponent<ItemObject>().referenceItem = item.data;
            newItemSlot.GetComponent<ItemObject>().amount = item.amount;
            newItemSlot.GetComponent<DragAndDropItem>().SetCanvas(lootInventory);
            newItemSlot.GetComponent<Slot>().Set(newItemSlot.GetComponent<ItemObject>());
        }
    }

    public void Clear()
    {
        foreach (Transform slot in lootInventory.transform)
        {
            Destroy(slot.gameObject);
        }
    }
}
