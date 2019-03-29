using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndCursor : MonoBehaviour
{
    public Texture2D mouse;
    public Texture2D andGate;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotspot = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setMouse()
    {
        Cursor.SetCursor(mouse, hotspot, cursorMode);
    }

    public void setAnd()
    {
        Cursor.SetCursor(andGate, hotspot, cursorMode);
    }
}
