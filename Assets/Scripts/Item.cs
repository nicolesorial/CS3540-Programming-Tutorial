using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemData referenceItem;
    
    public void OnHandlePickupItem()
    {
        InventorySystem.Current.Add(referenceItem);
        Destroy(gameObject);
    }
}