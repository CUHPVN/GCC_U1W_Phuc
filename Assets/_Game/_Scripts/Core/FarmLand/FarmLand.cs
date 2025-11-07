using System;
using System.Collections.Generic;
using UnityEngine;

public class FarmLand : MonoBehaviour, IClickable, IGridUnit
{
    private StateManager stateManager;
    public FarmLandStateLocked lockedState;
    public FarmLandStateEmpty emptyState;
    public FarmLandStateTilled tilledState;
    public FarmLandStateWatered wateredState;
    public Vector2Int position = Vector2Int.zero;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private List<Sprite> sprites= new List<Sprite>(3);
    private void Awake()
    {
        OnInit();
    }
    public void OnInit()
    {
        if(spriteRenderer!=null) spriteRenderer = GetComponent<SpriteRenderer>();
        stateManager = new();
        lockedState = new(stateManager,this);
        emptyState = new(stateManager,this);
        tilledState = new(stateManager, this);
        wateredState = new(stateManager, this);
        stateManager.ChangeState(lockedState);
    }
    private void Update()
    {
        if (GameManager.IsState(GameState.Pause)) return;
        if (stateManager != null)
        {
            stateManager.Update();
        }
    }

    public void OnClick()
    {
        if (stateManager.GetState() is FarmLandState currentFarmState)
        {
            currentFarmState.ClickOnFarm();
        }
    }

    public void SetPosition(int x, int y)
    {
        position.x = x;
        position.y = y;
    }
    public void ChangeSprite(int index)
    {
        if (index >= sprites.Count) return;
        else
        {
            spriteRenderer.sprite = sprites[index];
        }
    }
}
