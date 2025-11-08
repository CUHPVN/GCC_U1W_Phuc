using KatLib.Logger;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasGamePlay : UICanvas
{
    private List<InventoryUnit> inventory = new List<InventoryUnit>(36);
    [SerializeField] private List<ToolSlot> itemSlots = new List<ToolSlot>(9);
    [SerializeField] private ToolBarGamePlay toolBar;
    [SerializeField] private TMP_Text MoneyText;
    [SerializeField] private TMP_Text HungerText;
    [SerializeField] private TMP_Text DayText;

    public void OnEnable()
    {
        PlayerData.Instance.OnMoneyChange += UpdateMoney;
        PlayerData.Instance.OnHungerChange += UpdateHunger;
        PlayerData.Instance.OnDayChange += UpdateDay;


    }
    public void OnDisable()
    {
        if(PlayerData.Instance != null)
        {
            PlayerData.Instance.OnMoneyChange -= UpdateMoney;
            PlayerData.Instance.OnHungerChange -= UpdateHunger;
            PlayerData.Instance.OnDayChange -= UpdateDay;
        }

    }
    public void Start()
    {
        inventory = Inventory.Instance.GetInventory();
        if (toolBar != null)
        {
            itemSlots.AddRange(toolBar.GetItemSlots());
        }
        UpdateVisual();
    }
    public void UpdateVisual()
    {
        for (int i = 0; i < itemSlots.Count; i++)
        {
            itemSlots[i].UpdateItem(ItemDataBase.Instance.GetItemByID(inventory[i].ID), inventory[i].Count);
        }
    }
    private void UpdateMoney()
    {
        MoneyText.text = PlayerData.Instance.GetMoney().ToString();
    }
    private void UpdateHunger()
    {
        HungerText.text = PlayerData.Instance.GetHunger().ToString();
    }
    private void UpdateDay()
    {
        DayText.text =  $"Day {PlayerData.Instance.GetDay()}";
    }
    public void InventoryButton()
    {
        GameManager.ChangeState(GameState.Pause);
        UIManager.Instance.OpenUI<CanvasInventory>();
    }
    public void NextDayButton()
    {
        PlayerData.Instance.NextDay();
    }
    public void SettingsButton()
    {
        GameManager.ChangeState(GameState.Pause);
        UIManager.Instance.OpenUI<CanvasSettings>();
    }
    public void ReloadSceneButton()
    {
        SceneManager.LoadScene("Game");
    }
   
}
