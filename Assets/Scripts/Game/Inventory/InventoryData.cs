using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

[Serializable]
public class InventoryData
{
    [SerializeField] private List<InventoryItemData> _inventory = new List<InventoryItemData>();

    public int Count => _inventory.Count;

    public void AddItem(string id)
    {
        if (String.IsNullOrEmpty(id)) return;

        var item = GetItemData(id);

        if (item != null) throw new InvalidOperationException("exist");

        if (item == null) 
        {
            item = new InventoryItemData(id);
            _inventory.Add(item);
        }

        item.Value++;
    }

    public void RemoveItem(string id)
    {
        var item = GetItemData(id);

        if (item == null) return;

        item.Value --;
        
        if (item.Value <= 0) _inventory.Remove(item);
     }

    public bool IsContain(string id)
    {
        return _inventory.Exists(x => x.Id == id);
    }

    public IReadOnlyList<InventoryItemData> GetAllItems()
    {
        return new List<InventoryItemData>(_inventory);
    }

    private InventoryItemData GetItemData(string id)
    {
        foreach (var item in _inventory)
        {
            if (item.Id == id) return item;
        }
        return null;
    }
}
