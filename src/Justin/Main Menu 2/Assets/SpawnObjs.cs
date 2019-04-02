using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnObjs: MonoBehaviour
{
    public GameObject objectToSpawn;
    private bool made = false;
    // Use this for initialization
    private Stack<GameObject> gos;
    void Start()
    {
        gos = Undo1.getUndStk();
    }

    // Update is called once per frame
    void Update()
    {
        gos = Undo1.getUndStk();
        if (Input.GetMouseButtonDown(0) && made == false && gos.Count < 6)
        {
            Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spawnPosition.z = 0.0f;
            GameObject objectInstance = Instantiate(objectToSpawn, spawnPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
            made = true;
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            Destroy(GameObject.FindGameObjectWithTag("Spawner"));
        }
        else if(Input.GetMouseButtonDown(0) && gos.Count >= 6)
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            made = true;
        }
    }
}
