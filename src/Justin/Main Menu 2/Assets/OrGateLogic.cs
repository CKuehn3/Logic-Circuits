using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrGateLogic : MonoBehaviour
{
	public bool value; 
	public List<bool> inputs = new List<bool>(); 

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Gates Or";
    }

    // Update is called once per frame
    void Update()
    {
        calculateGateValue(); 
    }

    void calculateGateValue(){
        bool tempVal = false; 

        foreach(bool val in inputs){
            Debug.Log("Val: " + val); 
            if(val){
                tempVal = true; 
            }
        }

/*        for(int i = 0; i < inputs.Count; i++){
            if(inputs[i] == true){
                tempVal = true; 
            }
        }*/

        this.value = tempVal; 
    }
}
