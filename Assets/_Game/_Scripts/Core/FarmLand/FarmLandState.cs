using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FarmLandState : BaseState
{
    protected FarmLand farmLand;
    public FarmLandState(StateManager stateManager ,FarmLand farmLand):base(stateManager)
    {
        this.farmLand = farmLand;
        
    }
    public override void EnterState()
    {
    }

    public override void ExitState()
    {
    }

    public override void UpdateState()
    {
    }
    public abstract void ClickOnFarm();
    
}
