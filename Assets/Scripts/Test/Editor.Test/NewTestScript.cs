using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class NewTestScript
{
    private GameSession _session;


    [SetUp]
    public void Setup()
    { 
        _session = new GameObject().AddComponent<GameSession>();
    }

    [TearDown]
    public void TearDown()
    { 
        _session = null;
    }

    [Test]
    public void AddItem_WhenCall_IncreasedList()
    {
        _session.Data.Inventory.AddItem("1");
        Assert.AreEqual(1, _session.Data.Inventory.Count);
    }

    [Test]
    public void AddItem_WhenCall_DecreasedList()
    {
        _session.Data.Inventory.AddItem("1");
        _session.Data.Inventory.RemoveItem("1");
        Assert.AreEqual(0, _session.Data.Inventory.Count);
    }

    [Test]
    public void Contain_WhenCall_Num()
    {
        _session.Data.Inventory.AddItem("1");
        var first = _session.Data.Inventory.IsContain("1");
        var second = _session.Data.Inventory.IsContain("2");

        Assert.AreEqual(true, first);
        Assert.AreEqual(false, second);
    }

    [Test]
    public void GetAllItems_WhenCall_ReturnReadonleList()
    {
        _session.Data.Inventory.AddItem("1");
        IReadOnlyList<InventoryItemData> origin = _session.Data.Inventory.GetAllItems();
        var copy = (List<InventoryItemData>)origin;

        copy.Add(new InventoryItemData("1"));

        Assert.AreEqual(1, _session.Data.Inventory.Count);
        Assert.AreEqual(2, copy.Count);

    }

    [Test]
    public void AddItem_WhenCallNull_NoChanges()
    {
        _session.Data.Inventory.AddItem(null);
        Assert.AreEqual(0, _session.Data.Inventory.Count);
    }

    [Test]
    public void AddItem_WhenCallSameID_ThrowException()
    {
        _session.Data.Inventory.AddItem("1");

        var ex = Assert.Throws<InvalidOperationException>(() => _session.Data.Inventory.AddItem("1"));

        Assert.AreNotEqual(null, ex);
    }
}
