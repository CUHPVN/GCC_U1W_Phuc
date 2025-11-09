using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    [SerializeField] private CanvasInventory canvasInventory;
    [SerializeField] private List<ItemSlot> itemSlots = new List<ItemSlot>(27);

    private void Awake()
    {
        if (itemSlots.Count == 0)
            for (int i = 0; i < transform.childCount; i++)
            {
                itemSlots.Add(transform.GetChild(i).GetComponent<ItemSlot>());
            }
        for (int i = 0; i < itemSlots.Count; i++)
        {
            ItemSlot itemSlot = itemSlots[i];
            itemSlot.SetIndex(i+9);
            itemSlot.SetCanvas(canvasInventory);
        }
    }
    public List<ItemSlot> GetItemSlots()
    {
        return itemSlots;
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
    public void UpdateItem()
    {
        foreach (ItemSlot itemSlot in itemSlots)
        {
            itemSlot.UpdateItemInInven();
        }
    }
}
