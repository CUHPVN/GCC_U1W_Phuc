using KatLib.Logger;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmLandStateTilled : FarmLandState
{
    public FarmLandStateTilled(FarmLand farmLand) : base(farmLand)
    {
    }

    public override void EnterState(StateManager stateManager)
    {
        base.EnterState(stateManager);
        farmLand.ChangeSprite(2);
    }
    public override void ExitState()
    {
    }

    public override void UpdateState()
    {

    }
    public override void ClickOnFarm()
    {
        stateManager.ChangeState(farmLand.wateredState);
        LogCommon.Log(farmLand.position);
    }
}
