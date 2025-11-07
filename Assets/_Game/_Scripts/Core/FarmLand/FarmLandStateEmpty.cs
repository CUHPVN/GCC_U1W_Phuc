using KatLib.Logger;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmLandStateEmpty : FarmLandState
{
    public FarmLandStateEmpty(StateManager stateManager, FarmLand farmLand) : base(stateManager, farmLand)
    {
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
        stateManager.ChangeState(farmLand.tilledState);
        LogCommon.Log(farmLand.position);
    }
}
