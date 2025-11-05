using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public void IsInventoryContain(string id)
    { 
        GameSession.I.Data.Inventory.IsContain(id);
    }

    public void RemoveFromInventory(string id)
    {
        GameSession.I.Data.Inventory.RemoveItem(id);
    }
}
