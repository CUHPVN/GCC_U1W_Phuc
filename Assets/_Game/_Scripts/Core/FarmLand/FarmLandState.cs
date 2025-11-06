using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FarmLandState : BaseState
{
    protected FarmLand farmLand;
    public FarmLandState(FarmLand farmLand)
    {
        this.farmLand = farmLand;
    }
    public override void EnterState(StateManager stateManager)
    {
        base.EnterState(stateManager);
    }

    public override void ExitState()
    {
    }

    public override void UpdateState()
    {
    }
    public abstract void ClickOnFarm();
    
}
