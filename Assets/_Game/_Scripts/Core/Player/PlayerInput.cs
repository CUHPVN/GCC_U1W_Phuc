using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
        if (IsPointerOverUI()) return;
        RaycastHit2D hit = Physics2D.Raycast(InputManager.Instance.MousePos, Vector2.zero, 0);
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
        //RaycastHit2D hit = Physics2D.Raycast(InputManager.Instance.MousePos, Vector2.zero, 0, clickMask);
        //if (hit.collider != null)
        //{
        //    IClickable clickable = hit.collider.GetComponent<IClickable>();
        //    if (clickable != null)
        //    {
        //        clickable.OnClick();
        //    }
        //}
    }
    public static bool IsPointerOverUI()
    {
        if (EventSystem.current == null) return false;

#if UNITY_ANDROID || UNITY_IOS
    if (Input.touchCount > 0)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.GetTouch(0).position;

        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }
    return false;
#else
        return EventSystem.current.IsPointerOverGameObject();
#endif
    }
}
