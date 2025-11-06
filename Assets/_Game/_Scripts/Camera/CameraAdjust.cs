using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAdjust
{
    private Vector3 offSet = new Vector3(0, 0, -10);
    public Vector3 CalPos(Vector2 gridPos,Vector2 cellSize, Vector2 gridCenter)
    {
        Vector2 pos = gridCenter * cellSize;
        return ((Vector3)(gridPos + pos) + offSet);
    }
    public float CalOrthoSize(Vector2 vector2)
    {
        Bounds bounds = new Bounds();
        bounds.Encapsulate(Vector2.zero);
        bounds.Encapsulate(vector2);
        bounds.Expand(1);
        float x = 9f/16 * bounds.size.x/2; 
        float y = bounds.size.y/2;
        return Mathf.Max(x,y);
    }
}
