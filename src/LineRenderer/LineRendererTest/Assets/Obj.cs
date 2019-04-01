using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj : MonoBehaviour
{
    private bool input;
    private bool output;
    // Start is called before the first frame update
    void Start()
    {
        input = false;
        output = true;
    }

    void setInput()
    { 
        if (input == false)
        {
            input = true;
        }
    }

    void setOut()
    {
        if (output == false)
        {
            output = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
