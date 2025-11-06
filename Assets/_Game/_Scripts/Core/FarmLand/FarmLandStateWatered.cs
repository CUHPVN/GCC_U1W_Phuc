using KatLib.Logger;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmLandStateWatered : FarmLandState
{
    public FarmLandStateWatered(FarmLand farmLand):base(farmLand)
    {
    }


    public override void EnterState(StateManager stateManager)
    {
        base.EnterState(stateManager);
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
        LogCommon.Log("Check Harvest");
    }
}
