using KatLib.Logger;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmLandStateLocked : FarmLandState
{
    public FarmLandStateLocked(StateManager stateManager, FarmLand farmLand) : base(stateManager, farmLand)
    {
    }

    public override void EnterState()
    {
        farmLand.ChangeSprite(0);
        farmLand.priceVisual.gameObject.SetActive(true);
    }

    public override void ExitState()
    {
    }

    public override void UpdateState()
    {
        
    }
    public void UpdatePriceVisual()
    {
        int cost = (Mathf.Max(farmLand.position.x, farmLand.position.y) + 1);
        cost = cost * cost * 10;
        farmLand.priceText.text = cost.ToString();
    }
    public override void ClickOnFarm()
    {
        int cost = (Mathf.Max(farmLand.position.x, farmLand.position.y) + 1);
        cost = cost*cost*10;
        if (PlayerData.Instance.GetMoney()>=cost )
        {
            PlayerData.Instance.AddMoney(-cost);
            stateManager.ChangeState(farmLand.emptyState);
            farmLand.priceVisual.gameObject.SetActive(false);
        }
    }
}
