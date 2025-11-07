using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : Singleton<PlayerInput>
{
    [SerializeField] private LayerMask clickMask;
    void OnEnable()
    {
        InputManager.Instance.OnMouseDown += MouseDown;
        InputManager.Instance.OnMouseUp += MouseUp;
    }
    private void MouseDown()
    {
        if (GameManager.IsState(GameState.Pause)) return;
        RaycastHit2D hit = Physics2D.Raycast(InputManager.Instance.MousePos, Vector2.zero, 0, clickMask);
        if(hit.collider != null)
        {
            IClickable clickable = hit.collider.GetComponent<IClickable>();
            if(clickable != null )
            {
                clickable.OnClick();
            }
        }

    }
    private void MouseUp()
    {
        return;
        RaycastHit2D hit = Physics2D.Raycast(InputManager.Instance.MousePos, Vector2.zero, 0, clickMask);
        if (hit.collider != null)
        {
            IClickable clickable = hit.collider.GetComponent<IClickable>();
            if (clickable != null)
            {
                clickable.OnClick();
            }
        }
    }
}
