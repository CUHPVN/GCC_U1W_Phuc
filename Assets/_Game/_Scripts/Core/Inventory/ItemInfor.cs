using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfor : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text description;
    [SerializeField] private Button use;
    [SerializeField] private Button sell;
    [SerializeField] private TMP_Text sellText;
    [SerializeField] private Color Transfarent;
    [SerializeField] private GameObject left;
    [SerializeField] private GameObject right;
    private ItemSO itemSO;
    private int index;

    public void Awake()
    {
        use.onClick.AddListener(() =>Use());
        sell.onClick.AddListener(() => Sell());
    }
    public void SetInventoryUnit(int index)
    {
        this.index = index;
        itemSO = Inventory.Instance.GetItemSOByIndex(index);
        UpdateVisual();
    }
    public void UpdateVisual()
    {
        icon.sprite = itemSO.ItemSprite;
        InventoryUnit inventoryUnit = Inventory.Instance.GetItemByIndex(index);
        if (itemSO.UseAble) use.gameObject.SetActive(true); else use.gameObject.SetActive(false);
        if (itemSO.SellAble) sell.gameObject.SetActive(true); else sell.gameObject.SetActive(false);
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
        sellText.text = $"Sell for {itemSO.ItemPrice} Coin";
    }
    public void Use()
    {
        Inventory.Instance.UseItem(index);
        UpdateVisual();
    }
    public void Sell()
    {
        Inventory.Instance.SellItem(index);
        UpdateVisual();
    }
}
