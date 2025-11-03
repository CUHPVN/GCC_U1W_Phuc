using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager
{
    private IState _currentState;

    public StateManager(IState currentState)
    {
        _currentState = currentState;
        _currentState.EnterState();
    }
    public void Update()
    {
        _currentState?.UpdateState();   
    }
    public void ChangeState(IState state)
    {
        _currentState?.ExitState();
        _currentState = state;
        _currentState.EnterState();
    }
    public bool IsState(IState state) { return _currentState == state; }
    /*
    In Parent Class
    StateMachine stateM;
    <Any>State anyState;
    private void Awake()
    {
        stateM = GetComponent<StateMachine>();

        anyState = new <Any>(this); // inject
    }
     */
}
