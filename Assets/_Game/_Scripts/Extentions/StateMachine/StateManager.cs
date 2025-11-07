using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager
{
    private BaseState _currentState;

    public void Update()
    {
        _currentState?.UpdateState();   
    }
    public void ChangeState(BaseState state)
    {
        _currentState?.ExitState();
        _currentState = state;
        _currentState.EnterState();
    }
    public bool IsState(BaseState state) { return _currentState == state; }
    public BaseState GetState() => _currentState;
    /*
    In Parent Class
    StateMachine stateM;
    <Any>State anyState;
    private void Awake()
    {

        anyState = new <Any>(this); // inject
        stateM = new();
    }
     */
}
