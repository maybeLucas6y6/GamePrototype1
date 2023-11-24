using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public ItemProvenience itemProvenience;
    public TypeOfItem type;

    private GameObject holdItem
    {
        get
        {
            if (gameObject.transform.childCount > 0)
            {
                return gameObject.transform.GetChild(0).gameObject;
            }
            else
            {
                return null;
            }
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        var newItem = eventData.pointerDrag;
        if(newItem != null && (type == TypeOfItem.Default || type == newItem.GetComponent<ItemObject>().referenceItem.type))
        {
            if (holdItem == null)
            {
                newItem.transform.SetParent(transform);
                newItem.transform.position = transform.position;
            }
            else
            {
                if((holdItem.GetComponent<ItemObject>().referenceItem.name == newItem.GetComponent<ItemObject>().referenceItem.name) && 
                    holdItem.GetComponent<ItemObject>().referenceItem.type == TypeOfItem.Consumable)
                {
                    holdItem.GetComponent<ItemObject>().amount += newItem.GetComponent<ItemObject>().amount;
                    Destroy(newItem);
                    if (itemProvenience == ItemProvenience.External)
                    {
                        LootInventory.instance.currentLootbag.GetComponent<ShowLootbag>().UpdateInventory();
                    }
                    else
                    {
                        holdItem.GetComponent<Slot>().Set(holdItem.GetComponent<ItemObject>());
                    }
                }
            }
        }
    }
}

public enum ItemProvenience
{
    External,
    PlayerInventory
}