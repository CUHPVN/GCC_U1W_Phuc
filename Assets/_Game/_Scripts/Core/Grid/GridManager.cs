using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : Singleton<GridManager>
{
    [SerializeField] protected Vector2Int gridSize = Vector2Int.one;
    [SerializeField][Min(0.01f)] protected Vector2 cellSize = Vector2.one;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private FarmLand farmLandPrefab;
    private GridGeneric<FarmLand> farmGrid;

    private void Awake()
    {
        if (inputManager == null)
        {
            inputManager = FindAnyObjectByType<InputManager>();
            Debug.Log(inputManager);
        }
        farmGrid = new GridGeneric<FarmLand>(gridSize,cellSize,transform);
    }
    public (Vector2 gridPos, Vector2 cellSize, Vector2 gridCenter, Vector2 gridSize) GetGridInfor()
    {
        return farmGrid.GetGridInfor();
    }
    private void Start()
    {
         farmGrid.SpawnGrid(farmLandPrefab,transform);
    }
    private void Update()
    {
        
    }
}
