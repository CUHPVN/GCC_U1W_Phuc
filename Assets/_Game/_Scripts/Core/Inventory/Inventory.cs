using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUnit
{
    public string ID;
    public int Count;
}

public class Inventory : Singleton<Inventory>
{
    private List<InventoryUnit> inventory = new List<InventoryUnit>(36);
    [SerializeField] private ItemSO air;
    public ItemSO Item;

    private void Awake()
    {
        for (int i = 0; i < 36; i++)
        {
            InventoryUnit inventoryUnit = new();
            int rand = Random.Range(0, 2);
            if(rand == 0)
            {
                inventoryUnit.ID = air.GetItemID();
            }
            else
            {
                inventoryUnit.ID = Item.GetItemID();
            }
            inventoryUnit.Count = rand;
            inventory.Add(inventoryUnit);
        }
    }
    public List<InventoryUnit> GetInventory()
    {
        return inventory;
    }
}
