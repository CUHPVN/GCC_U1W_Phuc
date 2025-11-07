using KatLib.Logger;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBar : MonoBehaviour
{
    [SerializeField] private List<ToolSlot> itemSlots = new List<ToolSlot>(9);
    [SerializeField] private ItemSO temp;

    private void Awake()
    {
        if(itemSlots.Count == 0)
        for (int i = 0;i<transform.childCount;i++)
        {
            ToolSlot itemSlot = transform.GetChild(i).GetComponent<ToolSlot>();
            itemSlot.SetToolBar(this);
            itemSlot.UpdateItem(temp,2);
            itemSlots.Add(itemSlot);
        }
    }
    public void SetSelected(int index)
    {
        
    }
}
