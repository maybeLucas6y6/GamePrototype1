using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem current;

    private Dictionary<InventoryItemData, InventoryItem> m_itemDictionary;
    public Dictionary<string, List<string>> itemIDs;
    public List<InventoryItem> Inventory;

    private System.Random random = new();

    private void Awake()
    {
        Inventory = new List<InventoryItem>();
        m_itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
        itemIDs = new Dictionary<string, List<string>>();

        current = this;
    }

    public InventoryItem Get(InventoryItemData referenceData)
    {
        if(m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            return value;
        }
        return null;
    }

    // needs to be implemented
    // get by id

    public void Add(InventoryItemData referenceData, int amount = 1)
    {
        if(m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.AddToStack(amount);
        }
        else
        {
            InventoryItem newItem = new InventoryItem(referenceData);
            newItem.AddToStack(amount);
            Inventory.Add(newItem);
            m_itemDictionary.Add(referenceData, newItem);

            if (!itemIDs.ContainsKey(referenceData.id))
            {
                itemIDs.Add(referenceData.id, new List<string> { "initialized" });
            }
        }

        string newID = GenerateID(referenceData.id);
        itemIDs[referenceData.id].Add(newID);
        referenceData.stackID = newID;
    }

    public void Remove(InventoryItemData referenceData, int amount = 1)
    {
        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.RemoveFromStack(amount);

            itemIDs[referenceData.id].Remove(referenceData.stackID);

            if (value.stackSize <= 0)
            {
                Inventory.Remove(value);
                m_itemDictionary.Remove(referenceData);

                itemIDs.Remove(referenceData.id);
            }
        }
    }

    private string GenerateID(string item)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        string newID;
        do
        {
            newID = new string(Enumerable.Range(1, 6).Select(_ => chars[random.Next(chars.Length)]).ToArray());
        } while (itemIDs[item].Contains(newID));
        return newID;
    }
}
