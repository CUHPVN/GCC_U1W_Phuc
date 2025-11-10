using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : Singleton<PlayerData>
{
    private int money=100;
    private int day = 0;
    private int playerHunger = 10;
    [SerializeField] private Inventory inventory;
    public event Action OnMoneyChange;
    public event Action OnHungerChange;
    public event Action OnDayChange;
    public event Action OnNight;

    public void Start()
    {
        OnMoneyChange?.Invoke();
        OnHungerChange?.Invoke();
        inventory.RaiseInventoryUpdate();
        GameManager.ChangeState(GameState.Play);
    }
    public void OnEnable()
    {
        PlayerData.Instance.OnDayChange += CheckLose;
    }
    public void OnDisable()
    {
        if (PlayerData.Instance != null)
        {
            PlayerData.Instance.OnDayChange -= CheckLose;
        }
    }
    public int GetMoney() => money;
    public int GetHunger() => playerHunger;
    public int GetDay() => day;
    public bool CanBuy(int money) => this.money >= money;
    public void AddMoney(int count)
    {
        money += count;
        OnMoneyChange?.Invoke();
    }
    public void AddHunger(int count)
    {
        playerHunger += count;
        OnHungerChange?.Invoke();
    }
    public void Night()
    {
        OnNight?.Invoke();
    }
    public void NextDay()
    {
        int tmpHunger = playerHunger;
        playerHunger -= day/3;
        if(playerHunger < 0)
        {
            playerHunger = 0;
        }
        if(tmpHunger!=playerHunger)
        OnHungerChange?.Invoke();
        day++;
        OnDayChange?.Invoke();
    }
    public void CheckLose()
    {
        if (playerHunger <= 0)
        {
            Debug.Log("D");
            GameManager.ChangeState(GameState.Lose);
        }
    }
}
