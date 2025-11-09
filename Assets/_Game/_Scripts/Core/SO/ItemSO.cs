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
    [field: SerializeField] public int ItemPrice { get; private set; }
    [field: SerializeField] public bool UseAble { get; private set; }
    [field: SerializeField] public bool SellAble { get; private set; }


    public string GetItemID()
    {
        return $"{ItemType.ToString() }_{ItemName}";
    }
    public int GetCropHungerPoint()
    {
        if (ItemType == ItemType.Crop)
        {
            //Code Ban help me
            if (ItemName == "Wheat")
            {
                return 3;
            }
            if (ItemName == "Tomato")
            {
                return 5;
            }
        }
    
        return 0;
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
