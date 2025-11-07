// ItemDatabase.cs
using System.Collections.Generic;
using UnityEngine;

public class ItemDataBase : Singleton<ItemDataBase>
{
    private Dictionary<string, ItemSO> itemLookup = new Dictionary<string, ItemSO>();

    private void Awake()
    {
        ItemSO[] allItems = Resources.LoadAll<ItemSO>("ItemSO");

        foreach (ItemSO item in allItems)
        {
            if (!itemLookup.ContainsKey(item.GetItemID()))
            {
                itemLookup.Add(item.GetItemID(), item);
            }
            else
            {
                Debug.LogWarning($"Duplicate ItemID found: {item.GetItemID()}");
            }
        }
        Debug.Log($"Item Database loaded with {itemLookup.Count} items.");
    }

    public ItemSO GetItemByID(string itemID)
    {
        if (itemLookup.TryGetValue(itemID, out ItemSO item))
        {
            return item;
        }
        Debug.LogWarning($"Item with ID '{itemID}' not found in database.");
        return null;
    }
}