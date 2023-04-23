using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryList : MonoBehaviour
{
    public List<InventoryItem> items = new List<InventoryItem>();

    public void AddItem(InventoryItem item)
    {
        items.Add(item);
    }

    public void RemoveItem(InventoryItem item)
    {
        items.Remove(item);
    }
}
