using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class ToolSlot : MonoBehaviour
{
    [SerializeField] private ToolBarGamePlay toolBar;
    [SerializeField] private ItemSO itemSO;
    [SerializeField] private Image backImage;
    [SerializeField] private Image image;
    [SerializeField] private GameObject selectedField;
    [SerializeField] private TMP_Text countText;
    [SerializeField] private Color Transfarent;
    [SerializeField] private Color HoverColor;
    [SerializeField] private int index;
   
    public void OnPointerDown()
    {
        OnChose();
    }
    public void OnPointerEnter()
    {
        backImage.color = HoverColor;
    }
    public void OnPointerExit()
    {
        backImage.color = Color.white;
    }
    public void SetToolBar(ToolBarGamePlay toolBar)
    {
        this.toolBar = toolBar;
    }
    public void SetIndex(int index)
    {
        this.index = index;
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
        if (index<0||index>=36)
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
    public void OnChose()
    {
        toolBar.SetSelected(index);
    }
    public void SetSelected(bool value)
    {
        selectedField.SetActive(value);
    }

}
