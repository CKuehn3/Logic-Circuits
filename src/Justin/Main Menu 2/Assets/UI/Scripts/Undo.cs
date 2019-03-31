using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Undo : MonoBehaviour
{
    [SerializeField] private Button btn;
    private void Start()
    {
        btn.onClick.AddListener(Clear);
    }


    // Update is called once per frame
    public void Clear()
    {

        GameObject[] allGates = GameObject.FindGameObjectsWithTag("Gates");
        
        foreach(GameObject gate in allGates)
        {
            Destroy(gate);
        }
    }
}
