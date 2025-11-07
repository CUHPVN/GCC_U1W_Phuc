using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBarInGame : MonoBehaviour
{
    [SerializeField] private List<ItemSlot> itemSlots = new List<ItemSlot>(9);

    private void Awake()
    {
        if(itemSlots.Count == 0)
        for (int i = 0;i<transform.childCount;i++)
        {
            itemSlots.Add(transform.GetChild(i).GetComponent<ItemSlot>());
        }
    }
}
