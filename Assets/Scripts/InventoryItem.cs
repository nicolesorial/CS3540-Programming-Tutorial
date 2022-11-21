public class InventoryItem
{
    public ItemData data { get; private set; }
    public int stackSize { get; private set; }

    public InventoryItem(ItemData source)
    {
        data = source;
        AddToStack();
    }

    public void AddToStack()
    {
        stackSize++;
    }
    
    public void RemoveFromStack()
    {
        stackSize--;
    }

    public override string ToString()
    {
        return "[" + data + ": " + stackSize + "]";
    }
}
