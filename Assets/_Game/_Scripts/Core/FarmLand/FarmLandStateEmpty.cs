using KatLib.Logger;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmLandStateEmpty : FarmLandState
{
    protected ItemSO interactItem;

    public FarmLandStateEmpty(StateManager stateManager, FarmLand farmLand, ItemSO itemSO) : base(stateManager, farmLand)
    {
        this.interactItem = itemSO;
    }

    public override void EnterState()
    {
        farmLand.ChangeSprite(1);
    }

    public override void ExitState()
    {
    }

    public override void UpdateState()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateManager.ChangeState(farmLand.tilledState);
        }
    }
    public override void ClickOnFarm()
    {
        ItemSO itemSO = Inventory.Instance.GetSelectedItem();
        if (itemSO != null)
        {
            if(itemSO.ItemType == ItemType.Tool&&itemSO==interactItem)
            {
                stateManager.ChangeState(farmLand.tilledState);
            }
        }
    }
}
