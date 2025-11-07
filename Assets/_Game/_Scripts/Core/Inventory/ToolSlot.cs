using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToolSlot : MonoBehaviour
{
    [SerializeField] private ToolBar toolBar;
    [SerializeField] private ItemSO itemSO;
    [SerializeField] private Image image;
    [SerializeField] private Button slotButton;
    [SerializeField] private TMP_Text countText;
    [SerializeField] private int index;
    public void Awake()
    {
        if(slotButton != null)
        {
            slotButton.onClick.AddListener(()=>OnChose());
        }
    }
    public void SetToolBar(ToolBar toolBar)
    {
        this.toolBar = toolBar;
    }
    public void SetIndex(int index)
    {
        this.index = index;
    }
    public void UpdateItem(ItemSO itemSO,int count)
    {
        this.itemSO = itemSO;
        image.sprite = itemSO.ItemSprite;
        if (count == 0) countText.text = "";
        else countText.text = $"{count}";
    }
    public void OnChose()
    {
        toolBar.SetSelected(index);
    }
    
}
