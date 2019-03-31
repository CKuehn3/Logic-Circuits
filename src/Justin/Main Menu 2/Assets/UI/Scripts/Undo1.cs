using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Undo1 : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] private Button btn;
    private Stack<GameObject> reStk;
    private Stack<GameObject> undStk;

    private void Start()
    {
        reStk = new Stack<GameObject>();
        undStk = new Stack<GameObject>();
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
                if (!undStk.Contains(allGates[i]))
                {
                    undStk.Push(allGates[i]);
                }
                
                
            }

            
        }
        


    }
    public void undo()
    {
        if (undStk.Count != 0)
        {
            try
            {
                reStk.Push(undStk.Pop());
                //Debug.Log(reStk.Count);
                GameObject go = reStk.Peek();
                go.SetActive(false);
            }catch(System.Exception e)
            {
                Debug.Log("Can't pop off empty stack");
            }
            
        }
        else
        {

            Debug.Log("Can't pop off empty stack");
            // Debug.Log(undStk.Count);
            //Debug.Log(reStk.Count);
            //Destroy(obj);


        }
    }
    
    public void redo()
    {
        
        //Debug.Log(reStk.Count);
        if (reStk.Count != 0)
        {
            undStk.Push(reStk.Pop()); 
            GameObject go = undStk.Peek();
            go.SetActive(true);
            
        }
        else
        {
            Debug.Log("Can't pop off empty stack");

            //undStk.Push(obj);


        }
    }
    public void Clear()
    {

        GameObject[] allGates = GameObject.FindGameObjectsWithTag("Gates");

        foreach (GameObject gate in allGates)
        {
            Destroy(gate);
        }

        for(int i = 0; i < undStk.Count; i++)
        {
            undStk.Pop();
        }
        for (int i = 0; i < reStk.Count; i++)
        {
            reStk.Pop();
        }
    }
}
