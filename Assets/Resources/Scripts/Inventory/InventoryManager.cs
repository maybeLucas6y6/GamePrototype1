using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject m_slotPrefab;
    public GameObject player;

    void Start()
    {
        //InventorySystem.current.OnInventoryChangedEvent += OnUpdateInventory2;
    }

    private void OnUpdateInventory()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        DrawInventory();
    }

    private void DrawInventory()
    {
        foreach(InventoryItem item in InventorySystem.current.Inventory)
        {
            AddInventorySlot(item);
        }
        for(int i = 1; i <= 2 - InventorySystem.current.Inventory.Count; i++)
        {
            GameObject obj = Instantiate(m_slotPrefab);
            obj.transform.SetParent(transform, false);
        }
    }

    private void AddInventorySlot(InventoryItem item)
    {
        GameObject obj = Instantiate(m_slotPrefab);
        obj.transform.SetParent(transform, false);

        obj.GetComponent<Slot>().Set(item);
    }

    private void OnUpdateInventory2()
    {
        foreach(Transform t in transform)
        {
            if(t.transform.childCount > 0)
            {
                SetInventorySlot(t.transform.GetChild(0).GetComponent<Slot>());
            }
        }
    }

    private void SetInventorySlot(Slot slot)
    {
        slot.Set(slot.GetComponent<ItemObject>());
    }
}
