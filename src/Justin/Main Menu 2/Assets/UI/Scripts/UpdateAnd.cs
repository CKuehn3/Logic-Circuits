using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateAnd : MonoBehaviour
{
    AndCursor cursor;
    bool clicked;
    public GameObject aGate;
    // Start is called before the first frame update
    void Start()
    {
        cursor = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AndCursor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (clicked)
        {
            cursor.setAnd();
        }
    }

    void OnMouseDown()
    {
        clicked = true;
    }

    void OnMouseUp()
    {
        clicked = false;
        cursor.setMouse();

        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Instantiate(aGate, cursorPos, Quaternion.identity);
    }
}
