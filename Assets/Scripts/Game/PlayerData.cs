using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    [SerializeField] private InventoryData _inventoryData;

    public InventoryData Inventory => _inventoryData;

    public PlayerData()
    { 
        _inventoryData = new InventoryData();
    }

}
