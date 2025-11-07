using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private ItemSO itemSO;
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text countText;
    public void UpdateItem(ItemSO itemSO,int count)
    {
        this.itemSO = itemSO;
        image.sprite = itemSO.ItemSprite;
        if (count == 0) countText.text = "";
        else countText.text = $"{count}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
