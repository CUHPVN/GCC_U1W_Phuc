using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasLose : UICanvas
{
    public void OpenMainMenu()
    {
        Close(0);
        UIManager.Instance.OpenUI<CanvasMainMenu>();
    }
    public void OpenGamePlay()
    {
        Close(0);
        UIManager.Instance.OpenUI<CanvasGamePlay>();
    }
    public void CloseLose()
    {
        GameManager.ChangeState(GameState.Play);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
