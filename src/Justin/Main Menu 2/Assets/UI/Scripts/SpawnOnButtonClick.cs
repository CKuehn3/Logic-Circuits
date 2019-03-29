using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class SpawnOnButtonClick : MonoBehaviour
{
    public GameObject go;
    public Vector2 hotspot;
    public Texture2D cursorTexture;
    [SerializeField] private Button MyButton = null; // assign in the editor
    void Start()
    {
        MyButton.onClick.AddListener(toggleMaker);
    }

    void toggleMaker()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
        Instantiate(go, hotspot, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
