using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    [SerializeField] private List<ItemSlot> itemSlots = new List<ItemSlot>(27);

    private void Awake()
    {
        if (itemSlots.Count == 0)
            for (int i = 0; i < transform.childCount; i++)
            {
                itemSlots.Add(transform.GetChild(i).GetComponent<ItemSlot>());
            }
    }
    public List<ItemSlot> GetItemSlots()
    {
        return itemSlots;
    }
}
