using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotGateLogic : MonoBehaviour
{
	public bool value; 
	//public List<bool> inputs = new List<bool>(); 
    public bool tempVal; 
	
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Gates Not";
    }

    // Update is called once per frame
    void Update()
    {
      calculateGateValue();    
    }

    void calculateGateValue(){

        value = !tempVal;
    }
}
