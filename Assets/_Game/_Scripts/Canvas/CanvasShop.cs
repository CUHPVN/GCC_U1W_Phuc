using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CanvasShop : UICanvas
{
    [SerializeField] private List<ItemSlot> itemSlots = new List<ItemSlot>(27);
    [SerializeField] private int selectedIndex=-1;
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text description;
    [SerializeField] private Button buy;
    [SerializeField] private TMP_Text buyText;
    [SerializeField] private Color Transfarent;
    [SerializeField] private GameObject left;
    [SerializeField] private GameObject right;
    private ItemSO itemSO;
    public void Awake()
    {
        for(int i=0;i<itemSlots.Count;i++)
        {
            itemSlots[i].SetShopCanvas(this);
            itemSlots[i].SetIndex(i);
        }
        buy.onClick.AddListener(() => Buy());
    }
    public void OnEnable()
    {
        UpdateVisual();
        Shop.Instance.OnShopChange += UpdateVisual;
    }
    public void OnDisable()
    {
        if (Shop.Instance != null)
        {
            Shop.Instance.OnShopChange-=UpdateVisual;
        }
    }
    public void CloseShop()
    {
        Close(0);
    }
    public void SetChoseUnit(int index)
    {
        selectedIndex = index;
        for (int i = 0; i < itemSlots.Count; i++)
        {
            if (i == index)
            {
                itemSlots[i].SetSelected(true);
            }
            else
            {
                itemSlots[i].SetSelected(false);
            }
        }
        itemSO=Shop.Instance.GetItemSOByIndex(selectedIndex);
        SetInventoryUnit();
    }
    public void SetInventoryUnit()
    {
        UpdateInforVisual();
    }
    public void UpdateVisual()
    {
        List<InventoryUnit> inventory = Shop.Instance.GetInventory();
        for (int i = 0; i < itemSlots.Count; i++)
        {
            itemSlots[i].UpdateItem(ItemDataBase.Instance.GetItemByID(inventory[i].ID), inventory[i].Count);
        }
        UpdateInforVisual();
    }
    public void UpdateInforVisual()
    {
        if (selectedIndex == -1) return;
        icon.sprite = itemSO.ItemSprite;
        InventoryUnit inventoryUnit = Shop.Instance.GetItemByIndex(selectedIndex);
        if (inventoryUnit.Count <= 0)
        {
            icon.color = Transfarent;
            left.SetActive(false);
            right.SetActive(false);
        }
        else
        {
            icon.color = Color.white;
            left.SetActive(true);
            right.SetActive(true);
        }
        description.text = itemSO.ItemDescription;
        buyText.text = $"Buy for {itemSO.ItemPrice} Coin";
    }
    public void Buy()
    {
        Shop.Instance.BuyItem(selectedIndex);
    }
}
