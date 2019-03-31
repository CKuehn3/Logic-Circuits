using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Undo1 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Button btn;
    private Stack<GameObject> undStk = new Stack<GameObject>();
    void Start()
    {
        btn.onClick.AddListener(undo);

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] allGates = GameObject.FindGameObjectsWithTag("Gates");
       // Debug.Log(allGates.Length);
        if(allGates.Length != 0)
        {
            for(int i = 0; i < allGates.Length; i++)
            {
                undStk.Push(allGates[i]);
            }
            

        }
        

    }
    void undo()
    {
        if (undStk.Count == 0)
        {
            Debug.Log("Can't pop off empty stack");
        }
        else
        {
            GameObject obj = undStk.Pop();
            Destroy(obj);
        }
    }
}
