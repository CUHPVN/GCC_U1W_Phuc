using KatLib.Logger;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmLandStateLocked : FarmLandState
{
    public FarmLandStateLocked(FarmLand farmLand) : base(farmLand)
    {
    }

    public override void EnterState(StateManager stateManager)
    {
        base.EnterState(stateManager);
        farmLand.ChangeSprite(0);
    }

    public override void ExitState()
    {
    }

    public override void UpdateState()
    {
        
    }
    public override void ClickOnFarm()
    {
        LogCommon.Log("buy");
        stateManager.ChangeState(farmLand.emptyState);
    }
}
