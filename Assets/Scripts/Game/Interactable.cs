using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private string _id;

    public void Add()
    {
        GameSession.I.Data.Inventory.AddItem(_id);
    }
}
