using KatLib.Logger;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasInventory : UICanvas
{
    private List<InventoryUnit> inventory = new List<InventoryUnit>(36);
    [SerializeField] private List<ItemSlot> itemSlots = new List<ItemSlot>(36);
    [SerializeField] private Bag bag;
    [SerializeField] private Bag toolBar;
    private void Start()
    {
        inventory = Inventory.Instance.GetInventory();
        if (bag != null && toolBar != null)
        {
            itemSlots.AddRange(toolBar.GetItemSlots());
            itemSlots.AddRange(bag.GetItemSlots());
        }
        UpdateVisual();
    }
    public void UpdateVisual()
    {
        if (inventory.Count != itemSlots.Count)
        {
            LogCommon.Log("2 thang nay bi ngu");
            return;
        }
        for(int i=0;i<itemSlots.Count;i++)
        {
            itemSlots[i].UpdateItem(ItemDataBase.Instance.GetItemByID(inventory[i].ID), inventory[i].Count);
        }
    }
    public void CloseInventory()
    {
        GameManager.ChangeState(GameState.Play);
        Close(0);
    }
    public void OnMouseDown()
    {
        CloseInventory();
    }
}
