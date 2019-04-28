using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Undo1 : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] private Button btn;
    private static Stack<GameObject> reStk;
    private static Stack<GameObject> undStk;
    private static GameObject[] allGates;

    private void Start()
    {
        reStk = new Stack<GameObject>();
        undStk = new Stack<GameObject>();
    }
    // Update is called once per frame
    void Update()
    {
        allGates = FindGameObjectsWithTags(new string[] { "Gates And", "Gates Or", "Gates Not" , "Wires"});
        
        
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
                //overwrite();
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
        if (reStk.Count != 0 && !isFull())
        {
            try
            {
                undStk.Push(reStk.Pop());
                GameObject go = undStk.Peek();
                go.SetActive(true);
            }catch(System.Exception e)
            {
                Debug.Log("Can't pop off empty stack");
            }
            
            
        }
        
        else
        {
            Debug.Log("Can't pop off empty stack");
        }
    }
    public void Clear() //not clearing properly might  check if disconnect SpawnObjs.cs
    {

        
        int usize = undStk.Count;
        int rsize = reStk.Count;
        foreach (GameObject gate in allGates)
        {
            Destroy(gate);
        }
        Debug.Log(undStk.Count);
        for(int i = 0; i < usize; i++)
        {
            Debug.Log(undStk.Count);
            undStk.Pop();
        }
        Debug.Log(undStk.Count);
        for (int i = 0; i < rsize; i++)
        {
            reStk.Pop();
        }
        Debug.Log(reStk.Count);
    }

    public static Stack<GameObject> getUndStk()
    {
        return undStk;
    }

    void overwrite()
    {
        if (reStk.Count == 6)
        {
            int diff = undStk.Count;
            for(int i = 0; i < diff; i++)
            {
                Destroy(reStk.Pop());
            }
        }
    }
    bool isFull()
    {
        bool res = false;
        int count = 0;
        
        foreach (GameObject gate in allGates)
        {
            if (gate.activeSelf)
            {
                count = count + 1;
            }
        }

        if(count >= 10)
        {
            res = true;
            
        }
        count = 0;
        return res;
    }

    // found this code from the following https://answers.unity.com/questions/973677/add-gameobjects-with-different-tags-to-one-array.html
    GameObject[] FindGameObjectsWithTags(params string[] tags)
    {
        var all = new List<GameObject>();

        foreach (string tag in tags)
        {
            var temp = GameObject.FindGameObjectsWithTag(tag).ToList();
            all = all.Concat(temp).ToList();
        }

        return all.ToArray();
    }
}
