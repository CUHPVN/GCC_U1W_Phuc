// ItemDatabase.cs
using System.Collections.Generic;
using UnityEngine;

public class ItemDataBase : Singleton<ItemDataBase>
{
    private Dictionary<string, ItemSO> itemLookup = new Dictionary<string, ItemSO>();
    private Dictionary<string, CropSO> cropLookup = new Dictionary<string, CropSO>();
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
        CropSO[] allCrops = Resources.LoadAll<CropSO>("CropSO");

        foreach (CropSO crop in allCrops)
        {
            if (!cropLookup.ContainsKey(crop.GetCropID()))
            {
                cropLookup.Add(crop.GetCropID(), crop);
            }
            else
            {
                Debug.LogWarning($"Duplicate ItemID found: {crop.GetCropID()}");
            }
        }
        //Debug.Log($"Item Database loaded with {itemLookup.Count} items.");
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
    public CropSO GetCropByID(string cropID)
    {
        if (cropLookup.TryGetValue(cropID, out CropSO crop))
        {
            return crop;
        }
        Debug.LogWarning($"Item with ID '{cropID}' not found in database.");
        return null;
    }
}