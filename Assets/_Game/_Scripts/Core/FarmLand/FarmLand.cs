using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

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
    [SerializeField] private ItemSO Hoe;
    [SerializeField] private ItemSO WateringCan;
    [SerializeField] private Crop crop;
    public Transform priceVisual;
    public TMP_Text priceText;
    private void Awake()
    {
        OnInit();
    }
    public void OnEnable()
    {
        PlayerData.Instance.OnDayChange += NextDay;
    }
    public void OnDisable()
    {
        if (PlayerData.Instance != null)
        {
            PlayerData.Instance.OnDayChange -= NextDay;
        }
    }
    public void OnInit()
    {
        if(spriteRenderer!=null) spriteRenderer = GetComponent<SpriteRenderer>();
        stateManager = new();
        lockedState = new(stateManager,this);
        emptyState = new(stateManager,this,Hoe);
        tilledState = new(stateManager, this, WateringCan);
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
    public bool HasCrop()
    {
        return crop != null;
    }
    public bool CanHarvest() => crop.CanHavest();
    public void Harvest()
    {
        if (Inventory.Instance.IsFull())
        {
            //Do some thing
            return;
        }
        int count = UnityEngine.Random.Range(crop.GetResourceCount().x,crop.GetResourceCount().y);
        Inventory.Instance.AddItem(crop.GetResource(),count);
        SimplePool.Despawn(crop);
        crop = null;
    }
    public void SetCrop(string ID)
    {
        if (crop != null) return;
        crop= SimplePool.Spawn<Crop>(PoolType.Crop,transform.position,Quaternion.identity);
        crop.OnPlant(ItemDataBase.Instance.GetCropByID(ID));
    }
    public void SetPosition(int x, int y)
    {
        position.x = x;
        position.y = y;
        if (stateManager.IsState(lockedState))
        {
            lockedState.UpdatePriceVisual();
        }
    }
    public void ChangeSprite(int index)
    {
        if (index >= sprites.Count) return;
        else
        {
            spriteRenderer.sprite = sprites[index];
        }
    }
    public void NextDay()
    {
        if (stateManager.IsState(wateredState)&&crop != null)
        {
            crop.Grow();
        }
        if (stateManager.IsState(wateredState))
        {
            stateManager.ChangeState(tilledState);
        }
        else if (crop==null&&stateManager.IsState(tilledState))
        {
            stateManager.ChangeState(emptyState);
        }
    }
}
