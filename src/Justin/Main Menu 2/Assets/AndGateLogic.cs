using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndGateLogic : MonoBehaviour
{
	public bool value; 
    public List<bool> inputs = new List<bool>(); 
    

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Gates And";
        //value = false; 
    }

    // Update is called once per frame
    void Update()
    {
        calculateGateValue(); 
    }

    void calculateGateValue(){
        bool tempVal = true; 
        foreach(bool val in inputs){
            if(!val){
                tempVal = false; 
            }
        }

        this.value = tempVal; 
    }
}
