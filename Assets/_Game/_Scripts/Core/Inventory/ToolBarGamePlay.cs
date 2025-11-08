using KatLib.Logger;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBarGamePlay : MonoBehaviour
{
    [SerializeField] private List<ToolSlot> itemSlots = new List<ToolSlot>(9);

    private void Awake()
    {
        OnInit();
       
    }
    private void OnEnable()
    {
        Inventory.Instance.OnInventoryUpdate += UpdateItem;
    }
    private void OnDisable()
    {
        if (Inventory.Instance != null)
        {
            Inventory.Instance.OnInventoryUpdate -= UpdateItem;
        }
    }
    private void OnInit()
    {
        if (itemSlots.Count == 0)
            for (int i = 0; i < transform.childCount; i++)
            {
                ToolSlot itemSlot = transform.GetChild(i).GetComponent<ToolSlot>();

                itemSlots.Add(itemSlot);
            }
        for (int i = 0; i < itemSlots.Count; i++)
        {
            ToolSlot itemSlot = itemSlots[i];
            itemSlot.SetIndex(i);
            itemSlot.SetToolBar(this);
        }
    }
    public void SetSelected(int index)
    {
        for(int i = 0;i < itemSlots.Count;i++)
        {
            if (i == index) itemSlots[i].SetSelected(true); else itemSlots[i].SetSelected(false);
        }
        Inventory.Instance.SetSelectedIndex(index);
    }
    public void UpdateItem()
    {
        foreach (ToolSlot itemSlot in itemSlots)
        {
            itemSlot.UpdateItemInInven();
        }
    }
    public List<ToolSlot> GetItemSlots()
    {
        return itemSlots;
    }
}
