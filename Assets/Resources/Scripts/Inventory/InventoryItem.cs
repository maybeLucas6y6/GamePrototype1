[System.Serializable]
public class InventoryItem
{
    public InventoryItemData data;
    public int stackSize;

    public InventoryItem(InventoryItemData source)
    {
        data = source;
    }

    public void AddToStack(int amount = 1)
    {
        stackSize += amount;
    }

    public void RemoveFromStack(int amount = 1)
    {
        stackSize -= amount;
    }
}
