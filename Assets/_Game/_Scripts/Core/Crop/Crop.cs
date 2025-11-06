using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour
{
    [SerializeField] private int growLevel=0;
    [SerializeField] CropSO cropSO;

    public void OnPlant(CropSO cropSO)
    {
        this.cropSO = cropSO;
    }
    public void Grow()
    {
        growLevel++;
    }
}
