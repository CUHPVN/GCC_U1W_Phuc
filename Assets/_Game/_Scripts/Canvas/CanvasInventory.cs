using KatLib.Logger;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasInventory : UICanvas
{
    private CanvasGamePlay canvasGamePlay;
    private List<InventoryUnit> inventory = new List<InventoryUnit>(36);
    [SerializeField] private List<ItemSlot> itemSlots = new List<ItemSlot>(36);
    [SerializeField] private Bag bag;
    [SerializeField] private ToolBar toolBar;
    [SerializeField] private ItemInfor itemInfor;
    private void Start()
    {
        if (bag != null && toolBar != null)
        {
            itemSlots.AddRange(toolBar.GetItemSlots());
            itemSlots.AddRange(bag.GetItemSlots());
        }
        UpdateVisual();
    }
    public void UpdateVisual()
    {
        inventory = Inventory.Instance.GetInventory();
        if (inventory.Count != itemSlots.Count)
        {
            Debug.Log("2 thang nay bi ngu");
            return;
        }
        for(int i=0;i<itemSlots.Count;i++)
        {
            itemSlots[i].UpdateItem(ItemDataBase.Instance.GetItemByID(inventory[i].ID), inventory[i].Count);
        }
    }
    public void SetChoseUnit(int index)
    {
        for(int i = 0; i < itemSlots.Count; i++)
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
        itemInfor.SetInventoryUnit(index);
    }
    public void SetCanvasGamePlay(CanvasGamePlay canvasGamePlay)
    {
        if(this.canvasGamePlay!=null) UpdateVisual();
        this.canvasGamePlay = canvasGamePlay;
    }
    public void CloseInventory()
    {
        //GameManager.ChangeState(GameState.Play);
        canvasGamePlay.CloseInventory();
        Close(0);
    }
    public void OnMouseDown()
    {
        CloseInventory();
    }
}
