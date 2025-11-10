using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGeneric<T> where T : MonoBehaviour
{
    protected Vector2Int gridSize = Vector2Int.one;
    protected Vector2 cellSize = Vector2.one;

    private Transform transform;
    protected Vector2 gridPos => transform.position;

    protected Vector2 lastPos = new Vector2(0,0);
    protected float x => (float)gridSize.x / 2;
    protected float y => (float)gridSize.y / 2;
    public Vector2 gridCenter => new Vector2(x, y)*cellSize;

    private T[,] grid;
   

    public GridGeneric(Vector2Int gridSize,Vector2 cellSize, Transform transform)
    {
        this.gridSize = gridSize;
        this.cellSize = cellSize;
        this.transform = transform;
        grid = new T[gridSize.x, gridSize.y];
    }
    public (Vector2 gridPos, Vector2 cellSize, Vector2 gridCenter, Vector2 gridSize) GetGridInfor()
    {
        return (gridPos, cellSize, gridCenter, gridSize);
    }
    public void SpawnGrid(T prefab,Transform parent) 
    {
        for (int i = 0; i < gridSize.x; i++)
        {
            for (int j = 0; j < gridSize.y; j++)
            {
                Vector2 pos = gridPos + new Vector2(i + 0.5f, j + 0.5f) * cellSize;
                T gobj = GameObject.Instantiate(prefab, pos,Quaternion.identity);
                gobj.transform.SetParent(parent);
                gobj.GetComponent<IGridUnit>()?.SetPosition(i, j);
                grid[i,j]= gobj;
            }
        }
    }

    protected Vector2 ToGridPos(Vector2 pos)
    {
        pos -= gridPos;
        pos /= cellSize;
        pos = Vector2Int.CeilToInt(pos) - Vector2Int.one;
        return pos;
    }
    public Vector2Int GetGridIndexByPos(Vector2 pos)
    {
        pos -= gridPos;
        pos /= cellSize;
        return Vector2Int.CeilToInt(pos) - Vector2Int.one;
    }

    public T GetGridByIndex(int x,int y)
    {
        if (x >= 0 && x < gridSize.x && y >= 0 && y < gridSize.y)
        return grid[x,y];
        return null;
    }
    public bool IsEmptySlot(int x, int y)
    {
        if (grid[x, y] == null) return true;
        return false;
    }
    public void SetDataByIndex(int x,int y,T t)
    {
        if (x >= 0 && x < gridSize.x && y >= 0 && y < gridSize.y)
        {
            grid[x, y]=t;
        }
    }
    public void ClearDataByIndex(int x, int y)
    {
        if (x >= 0 && x < gridSize.x && y >= 0 && y < gridSize.y)
        {
            grid[x, y] = null;
        }
    }
    public Vector2 GetGridPos(int x,int y)
    {
        return gridPos+ new Vector2Int(x,y)*cellSize + cellSize* Vector2.one/2f;
    }
    protected virtual bool CheckMove()
    {
        return (Vector2.Distance(lastPos, gridPos) >= 0.01f);
    }
   
    public void DrawGrid()
    {
        Gizmos.color = Color.green;
        for (int i = 0; i < gridSize.x; i++)
        {
            for (int j = 0; j < gridSize.y; j++)
            {
                Vector2 pos = gridPos + new Vector2(i + 0.5f, j + 0.5f) * cellSize;
                if (grid != null) { 
                if (grid[i, j] != null) Gizmos.color = Color.red;
                else Gizmos.color = Color.green; 
                }
                Gizmos.DrawWireCube(pos, cellSize*0.95f);
            }
        }
    }
   
}
