using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    private static GameState gameState=GameState.Play;
    
    public static bool IsState(GameState state)
    {
        return gameState == state;
    }
    public static void ChangeState(GameState state)
    {
        if(gameState != state)
        {
            gameState = state;
        }
    }
}
public enum GameState
{
    None=0,
    Play=1,
    Pause=2,
}
