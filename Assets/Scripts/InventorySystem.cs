using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private Dictionary<ItemData, InventoryItem> _itemDictionary;
    public List<InventoryItem> inventory { get; private set; }
    private static InventorySystem _instance;

    // Singleton pattern
    public static InventorySystem Current
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("Inventory system is null");
            }

            return _instance;
        }
    }

    void Awake()
    {
        Debug.Log("In Awake");
        inventory = new List<InventoryItem>();
        _itemDictionary = new Dictionary<ItemData, InventoryItem>();
        _instance = this;
    }

    public void Add(ItemData referenceData)
    {
        if (_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.AddToStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(referenceData);
            inventory.Add(newItem);
            _itemDictionary.Add(referenceData, newItem);
        }
        
        Debug.Log("Current Inventory: " + buildCurrentInventory());
    }

    public void Remove(ItemData referenceData)
    {
        if (_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.RemoveFromStack();

            if (value.stackSize == 0)
            {
                inventory.Remove(value);
                _itemDictionary.Remove(referenceData);
            }
        }
        
        Debug.Log("Current Inventory: " + buildCurrentInventory());
    }

    private string buildCurrentInventory()
    {
        string inventoryString = "";
        foreach (InventoryItem item in inventory)
        {
            inventoryString += item.ToString();
        }

        return inventoryString;
    }
}