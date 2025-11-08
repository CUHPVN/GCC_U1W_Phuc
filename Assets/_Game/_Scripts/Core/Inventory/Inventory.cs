using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUnit
{
    public string ID;
    public int Count=0;
    public InventoryUnit()
    {
    }

    public InventoryUnit(string id,int count)
    {
        ID= id;
        Count= count;
    }
}

public class Inventory : Singleton<Inventory>
{
    private List<InventoryUnit> inventory = new List<InventoryUnit>(36);
    [SerializeField] private int selectedIndex=-1;
    [SerializeField] private ItemSO air;
    public event Action OnInventoryUpdate;
    public ItemSO ItemHoe;
    public ItemSO ItemWateringCan;
    public ItemSO ItemSeed;

    private void Awake()
    {
        OnInit();
    }
    public void OnInit()
    {
        for (int i = 0; i < 36; i++)
        {
            InventoryUnit inventoryUnit = new();
            inventoryUnit.ID = air.GetItemID();
            inventoryUnit.Count = 0;
            inventory.Add(inventoryUnit);
        }
    }
    public void Start()
    {
        inventory[0]= new InventoryUnit(ItemHoe.GetItemID(),1);
        inventory[1]= new InventoryUnit(ItemWateringCan.GetItemID(),1);
        inventory[2]= new InventoryUnit(ItemSeed.GetItemID(),5);
        OnInventoryUpdate?.Invoke();
    }
    public bool IsFull()
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].ID == air.GetItemID())
            {
                return false;
            }
        }
        return true;
    }
    public void AddItem(ItemSO itemSO,int count)
    {
        string ID=itemSO.GetItemID();
        int emptyIndex = inventory.Count;
        for(int i = 0; i < inventory.Count; i++)
        {
            if(inventory[i].ID == ID)
            {
                inventory[i].Count+=count;
                OnInventoryUpdate?.Invoke();
                return;
            }
            if (inventory[i].ID == air.GetItemID()&&i<emptyIndex)
            {
                emptyIndex = i;
            }
        }
        if (emptyIndex != inventory.Count)
        {
            InventoryUnit inventoryUnit = new(ID, count);
            inventory[emptyIndex]= inventoryUnit;
            OnInventoryUpdate?.Invoke();
        }
    }
    public void RaiseInventoryUpdate()
    {
        OnInventoryUpdate?.Invoke();
    }
    public List<InventoryUnit> GetInventory()
    {
        return inventory;
    }
    public void SetSelectedIndex(int index)
    {
        selectedIndex = index;
    }
    public InventoryUnit GetItemByIndex(int index)
    {
        return inventory[index];
    }
    public ItemSO GetSelectedItem()
    {
        if (selectedIndex<0||selectedIndex>=9) return null;
        return ItemDataBase.Instance.GetItemByID(inventory[selectedIndex].ID);
    }
}
