using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : GameUnit
{
    [SerializeField] private int growLevel=0;
    [SerializeField] CropSO cropSO;
    [SerializeField] private SpriteRenderer sprite;

    public void OnEnable()
    {
    }
    public void OnDisable()
    {
    }
    public void OnInit()
    {
        growLevel = 0;
    }
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
    public void OnGrow()
    {
        SimplePool.Spawn<GrowParticle>(PoolType.GrowParticle, transform.position, Quaternion.identity);
    }
    public void Grow()
    {
        growLevel++;
        float growthRatio = (float)growLevel / cropSO.CropGrowingTime;
        int index = (int)(growthRatio * cropSO.CropSprites.Count);
        if (index >= cropSO.CropSprites.Count)
        {
            index = cropSO.CropSprites.Count - 1;
        }
        if (index == cropSO.CropSprites.Count - 1 && growLevel < cropSO.CropGrowingTime)
        {
            sprite.sprite = cropSO.CropSprites[index - 1];
        }
        else
        {
            sprite.sprite = cropSO.CropSprites[index];
        }
    }
}
