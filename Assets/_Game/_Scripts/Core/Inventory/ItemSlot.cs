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
    [SerializeField] private TMP_Text countText;
    [SerializeField] private Color Transfarent;
    [SerializeField] private int index;


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

    // Update is called once per frame
    void Update()
    {
        
    }
}
