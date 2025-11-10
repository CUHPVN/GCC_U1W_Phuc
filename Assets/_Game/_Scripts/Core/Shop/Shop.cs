using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Shop : Singleton<Shop>
{
    [SerializeField] private List<InventoryUnit> inventory = new List<InventoryUnit>(27);
    [SerializeField] private List<ItemSO> shopStuff = new List<ItemSO>();
    [SerializeField] private ItemSO air;
    public event Action OnShopChange;
    private void Awake()
    {
        for (int i = 0; i < 27; i++)
        {
            inventory.Add(new(air.GetItemID(), 0));
        }
    }
    void Start()
    {
        ChangeShopStuff();
    }

    private void OnEnable()
    {
        PlayerData.Instance.OnDayChange += ChangeShopStuff;
    }
    private void OnDisable()
    {
        if (PlayerData.Instance!=null)
        {
            PlayerData.Instance.OnDayChange -= ChangeShopStuff;
        }
    }
    public void ChangeShopStuff()
    {
        int ran; 
        for (int i = 0; i < inventory.Count; i++)
        {
            ran = UnityEngine.Random.Range(0, shopStuff.Count);
            ItemSO itemSO = shopStuff[ran];
            int count = UnityEngine.Random.Range(0, 6);
            if (count != 0)
            {
                inventory[i] = new(itemSO.GetItemID(),count);
            }
            else
            {
                inventory[i] = new(air.GetItemID(), 0);
            }
        }
        for(int i = 0; i < inventory.Count-1; i++)
        {
            for(int j = i + 1; j < inventory.Count; j++)
            {
                if (inventory[i].Count < inventory[j].Count)
                {
                    InventoryUnit inventoryUnit = inventory[i];
                    inventory[i] = inventory[j];
                    inventory[j] = inventoryUnit;
                }
            }
        }
        OnShopChange?.Invoke();
    }
    public void BuyItem(int index)
    {
        ItemSO itemSO = GetItemSOByIndex(index);
        if (!PlayerData.Instance.CanBuy(itemSO.ItemPrice))
        {
            return;
        }
        inventory[index].Count -= 1;
        PlayerData.Instance.AddMoney(-itemSO.ItemPrice);
        Inventory.Instance.AddItem(itemSO, 1);
        if (inventory[index].Count <= 0)
        {
            InventoryUnit inventoryUnit = new();
            inventoryUnit.ID = air.GetItemID();
            inventoryUnit.Count = 0;
            inventory[index] = inventoryUnit;
        }
        OnShopChange?.Invoke();
    }
    public List<InventoryUnit> GetInventory()
    {
        return inventory;
    }
    public ItemSO GetItemSOByIndex(int index)
    {
        return ItemDataBase.Instance.GetItemByID(inventory[index].ID);
    }
    public InventoryUnit GetItemByIndex(int index)
    {
        return inventory[index];
    }
}
