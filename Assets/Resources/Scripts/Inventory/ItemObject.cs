using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public InventoryItemData referenceItem;
    public int amount;

    public void OnHandlePickupItem()
    {
        if (referenceItem != null)
        {
            InventorySystem.current.Add(referenceItem);
        }
        //InventorySystem.current.InventoryChangedEvent();
        //Destroy(gameObject);
    }
}
