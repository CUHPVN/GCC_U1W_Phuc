using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ItemSO",menuName = "SO/ItemSO")]
public class ItemSO : ScriptableObject
{
    [field:SerializeField] public ItemType ItemType { get; private set;}
    [field:SerializeField] public string ItemName { get; private set; }
    [field: SerializeField] public string ItemDescription { get; private set; }
    [field:SerializeField] public Sprite ItemSprite { get; private set; }
    [field:SerializeField] public CropSO SeedCrop { get; private set; }

    public string GetItemID()
    {
        return $"{ItemType.ToString() }_{ItemName}";
    }
}
public enum ItemType
{
    Air=0,
    Seed=1,      
    Crop=2,     
    Consumable=3, 
    Resource=4, 
    Tool=5,      
}
