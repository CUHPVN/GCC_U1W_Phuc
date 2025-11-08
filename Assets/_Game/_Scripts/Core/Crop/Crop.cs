using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : GameUnit
{
    [SerializeField] private int growLevel=0;
    [SerializeField] CropSO cropSO;
    [SerializeField] private SpriteRenderer sprite;

    public void OnPlant(CropSO cropSO)
    {
        this.cropSO = cropSO;
        int index = (int)(growLevel * cropSO.CropGrowingTime / cropSO.CropSprites.Count);
        sprite.sprite = cropSO.CropSprites[index];
    }
    public bool CanHavest()
    {
        return growLevel >= cropSO.CropGrowingTime;
    }
    public ItemSO GetResource()
    {
        return cropSO.CropResource;
    }
    public Vector2Int GetResourceCount()
    {
        return cropSO.ResourceCount;
    }
    public void Grow()
    {
        if (growLevel >= cropSO.CropSprites.Count) return;
        growLevel++;
        int index = (int)(growLevel * cropSO.CropGrowingTime/cropSO.CropSprites.Count);
        sprite.sprite = cropSO.CropSprites[index];
    }
}
