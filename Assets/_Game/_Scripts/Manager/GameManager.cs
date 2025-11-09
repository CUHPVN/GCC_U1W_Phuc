using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    private static GameState gameState=GameState.Play;
    public static event Action OnChangeState;
    public static bool IsState(GameState state)
    {
        return gameState == state;
    }
    public static void ChangeState(GameState state)
    {
        if (gameState != state)
        {
            gameState = state;
            OnChangeState?.Invoke();
        }
    }
    
}
public enum GameState
{
    None=0,
    Play=1,
    Pause=2,
    Lose=3,
}
