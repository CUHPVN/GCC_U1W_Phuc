using KatLib.Logger;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class CanvasGamePlay : UICanvas
{
    private List<InventoryUnit> inventory = new List<InventoryUnit>(36);
    [SerializeField] private List<ToolSlot> itemSlots = new List<ToolSlot>(9);
    [SerializeField] private ToolBarGamePlay toolBar;
    [SerializeField] private TMP_Text MoneyText;
    [SerializeField] private TMP_Text HungerText;
    [SerializeField] private TMP_Text DayText;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private Light2D light2D;
    [SerializeField] private Transform nextDayButton;
    [SerializeField] private UIPopUp shopPopUp;
    [SerializeField] private UIPopUp daycountPopUp;
    [SerializeField] private UIPopUp nextdayPopUp;
    [SerializeField] private UIPopUp moneyPopUp;
    [SerializeField] private UIPopUp hungerPopUp;


    public void Awake()
    {
        if (light2D == null)
        {
            light2D = FindAnyObjectByType<Light2D>();
        }
    }
    public void OnEnable()
    {
        PlayerData.Instance.OnMoneyChange += UpdateMoney;
        PlayerData.Instance.OnHungerChange += UpdateHunger;
        PlayerData.Instance.OnDayChange += UpdateDay;
        GameManager.OnChangeState += LosePanel;

    }
    public void OnDisable()
    {
        StopAllCoroutines();
        if(PlayerData.Instance != null)
        {
            PlayerData.Instance.OnMoneyChange -= UpdateMoney;
            PlayerData.Instance.OnHungerChange -= UpdateHunger;
            PlayerData.Instance.OnDayChange -= UpdateDay;
        }
        GameManager.OnChangeState -= LosePanel;

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
        moneyPopUp.PopUp();
    }
    private void UpdateHunger()
    {
        HungerText.text = PlayerData.Instance.GetHunger().ToString();
        hungerPopUp.PopUp();
    }
    private void UpdateDay()
    {
        DayText.text =  $"Day {PlayerData.Instance.GetDay()}";
    }
    public void InventoryButton()
    {
        //GameManager.ChangeState(GameState.Pause);
        toolBar.ToogleSelected(false);
        CanvasInventory canvasInventory= UIManager.Instance.OpenUI<CanvasInventory>();
        canvasInventory.SetCanvasGamePlay(this);
    }
    public void ShopButton()
    {
        UIManager.Instance.OpenUI<CanvasShop>();
    }
    public void CloseInventory()
    {
        toolBar.ToogleSelected(true);
    }
    public void NextDayButton()
    {
        nextDayButton.gameObject.SetActive(false);  
        StartCoroutine(NextDay());
    }
    public IEnumerator NextDay()
    {
        float time = 0,duration=2f;
        PlayerData.Instance.Night();
        while (time < duration)
        {
            time += Time.deltaTime;
            light2D.intensity = curve.Evaluate(time / (duration));
            yield return null;
        }
        light2D.intensity = 1;
        nextDayButton.gameObject.SetActive(true);
        //
        PlayerData.Instance.NextDay();
        shopPopUp.PopUp();
        daycountPopUp.PopUp();
        nextdayPopUp.PopUp();
        yield break;
    }
    public void SettingsButton()
    {
        GameManager.ChangeState(GameState.Pause);
        UIManager.Instance.OpenUI<CanvasSettings>();
    }
    public void LosePanel()
    {
        if (GameManager.IsState(GameState.Lose))
        {
            UIManager.Instance.OpenUI<CanvasLose>();
        }
    }
    public void ReloadSceneButton()
    {
        SceneManager.LoadScene("Game");
    }
   
}
