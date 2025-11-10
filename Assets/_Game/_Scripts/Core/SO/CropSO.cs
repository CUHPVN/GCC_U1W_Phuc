using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CropSO",menuName = "SO/CropSO")]
public class CropSO : ScriptableObject
{
    [field:SerializeField] public CropType   CropType { get; private set;}
    [field:SerializeField] public string CropName { get; private set; }
    [field: SerializeField] public string CropDescription { get; private set; }
    [field:SerializeField] public List<Sprite> CropSprites { get; private set; }
    [field: SerializeField] public float CropGrowingTime { get; private set; }
    [field: SerializeField] public Vector2Int ResourceCount { get; private set; }
    [field: SerializeField] public ItemSO CropResource { get; private set; }


    public string GetCropID()
    {
        return $"{CropType.ToString()}_{CropName}";
    }
}
public enum CropType
{
    Wheat=0,
    Potato=1,
    Carrot=2,
    Tomato=3,
}
