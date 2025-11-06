using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasInventory : UICanvas
{
    public void AddPoint()
    {
           
    }
    private void Update()
    {
        //AddPoint();
    }
    public void SettingsButton()
    {
        Close(0);
        UIManager.Instance.OpenUI<CanvasSettings>();
    }
    public void ReloadSceneButton()
    {
        SceneManager.LoadScene("Game");
    }
}
