using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnObjs: MonoBehaviour
{
    public GameObject objectToSpawn;
    private bool made = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetMouseButtonDown(0) && made == false)
        {
            Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spawnPosition.z = 0.0f;
            GameObject objectInstance = Instantiate(objectToSpawn, spawnPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
            made = true;
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            Destroy(GameObject.FindGameObjectWithTag("Spawner"));
        }
    }
}
