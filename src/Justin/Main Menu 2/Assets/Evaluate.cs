using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evaluate : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick(){
        GameObject inputx  = GameObject.Find("Input X"); 
        GameObject inputy = GameObject.Find("Input Y"); 
        GameObject inputz = GameObject.Find("Input Z"); 
    	inputx.GetComponent<TestPositiveInput>().setValue(true); 
    	inputy.GetComponent<TestPositiveInput>().setValue(true); 
        inputz.GetComponent<TestPositiveInput>().setValue(false); 

        GameObject result = GameObject.Find("Result"); 
        Debug.Log("RESULT: " + result.GetComponent<Result>().value); 
    }
}
