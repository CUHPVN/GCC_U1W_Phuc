using KatLib.Logger;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class FarmLandStateWatered : FarmLandState
{
    public FarmLandStateWatered(StateManager stateManager, FarmLand farmLand) : base(stateManager, farmLand)
    {
    }
    public override void EnterState()
    {
        farmLand.ChangeSprite(3);

    }

    public override void ExitState()
    {
    }

    public override void UpdateState()
    {
    }
    public override void ClickOnFarm()
    {
        ItemSO itemSO = Inventory.Instance.GetSelectedItem();
        if (farmLand.HasCrop() && farmLand.CanHarvest())
        {
            farmLand.Harvest();
        } else
        if (itemSO.ItemType == ItemType.Seed && !farmLand.HasCrop())
        {
            Inventory.Instance.PlantSeed(itemSO.GetItemID());
            farmLand.SetCrop(itemSO.SeedCrop.GetCropID());
        }
    }
}
