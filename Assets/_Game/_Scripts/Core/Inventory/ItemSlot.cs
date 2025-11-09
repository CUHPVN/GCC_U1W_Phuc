using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private ItemSO itemSO;
    [SerializeField] private Image image;
    [SerializeField] private Button button;
    [SerializeField] private CanvasInventory canvasInventory;
    [SerializeField] private TMP_Text countText;
    [SerializeField] private Color Transfarent;
    [SerializeField] private GameObject selectedField;
    [SerializeField] private int index;

    public void OnEnable()
    {
        button.onClick.AddListener(() => OnItemChose());
    }
    public void SetCanvas(CanvasInventory canvasInventory)
    {
        this.canvasInventory = canvasInventory;
    }
    public void SetIndex(int index)
    {
        this.index = index;
    }
    public void OnItemChose()
    {
        canvasInventory.SetChoseUnit(index);
    }
    public void UpdateItem(ItemSO itemSO, int count)
    {
        this.itemSO = itemSO;
        image.sprite = itemSO.ItemSprite;
        if (count == 0)
        {
            countText.text = "";
            image.color = Transfarent;
        }
        else
        {
            countText.text = $"{count}";
            image.color = Color.white;
        }
    }
    public void UpdateItemInInven()
    {
        if (index < 0 || index >= 36)
        {
            return;
        }
        InventoryUnit inventoryUnit = Inventory.Instance.GetItemByIndex(index);
        ItemSO itemSO = ItemDataBase.Instance.GetItemByID(inventoryUnit.ID);
        int count = inventoryUnit.Count;

        this.itemSO = itemSO;
        image.sprite = itemSO.ItemSprite;
        if (count == 0)
        {
            countText.text = "";
            image.color = Transfarent;
        }
        else
        {
            countText.text = $"{count}";
            image.color = Color.white;
        }
    }
    public void SetSelected(bool value)
    {
        selectedField.SetActive(value);
    }
    public int GetIndex() => index;
}
