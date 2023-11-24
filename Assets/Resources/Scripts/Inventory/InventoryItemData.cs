using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Item", fileName = "NewItem", order = 1)]
public class InventoryItemData : ScriptableObject
{
    [HideInInspector] public string id;
    [HideInInspector] public string stackID;
    public string displayName;
    public Sprite icon;
    public TypeOfItem type;
    public int amount;
    public string scriptName;

    public static List<string> ids = new List<string>();
    private static System.Random random = new System.Random();
    private InventoryItemData()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        string newId;
        do
        {
            newId = new string(Enumerable.Range(1, 6).Select(_ => chars[random.Next(chars.Length)]).ToArray());
        } while(ids.Contains(newId));
        id = newId;
        ids.Add(id);

        amount = 1;
    }
}

public enum TypeOfItem
{
    Default,
    Consumable,
    Weapon,
    Ability,
    Armor,
    Ring
};