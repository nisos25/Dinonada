using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D cursorTextureBalance;
    public Texture2D cursorTextureUI;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private static CursorManager instance = null;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    //void Update()
    //{
    //    if(Input.GetMouseButtonDown(0))
    //        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);

    //    if(Input.GetMouseButtonUp(0))
    //        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    //}

    public void changeCursorBalance()
    {
        Cursor.SetCursor(cursorTextureBalance, hotSpot, cursorMode);
    }

    public void changerCursorUI()
    {
        Cursor.SetCursor(cursorTextureUI, hotSpot, cursorMode);
    }

    public void HideCursor()
    {
        Cursor.visible = false;
    }

}
