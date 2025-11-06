using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    protected StateManager stateManager;
    public virtual void EnterState(StateManager stateManager)
    {
        this.stateManager = stateManager;
    }
    public abstract void UpdateState();
    public abstract void ExitState();
    /*
    In Child Class
    Any : BaseState
    {
        GameObject go;
        public Any(GameObject go){
            //cache
        }
        EnterState(){
        }
        UpdateState(){
        }
        ExitState(){
        }
    }
     */
}
