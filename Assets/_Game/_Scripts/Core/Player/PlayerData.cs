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

    public void Start()
    {
        OnMoneyChange?.Invoke();
        OnHungerChange?.Invoke();
        inventory.RaiseInventoryUpdate();
    }
    public int GetMoney() => money;
    public int GetHunger() => playerHunger;
    public int GetDay() => day;
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
    public void NextDay()
    {
        playerHunger -= day;
        day++;
        OnDayChange?.Invoke();
        OnHungerChange?.Invoke();
    }
}
