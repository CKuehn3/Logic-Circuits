using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPositiveInput : MonoBehaviour
{
	public bool value; 
    GameObject child; 

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Input Positive";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setValue(bool val){
        value = val; 
        alterChild(); 
        //Debug.Log("Input Child: " + child); 
        //Debug.Log("Input Value: " + value); 
    }

    public void setChild(GameObject obj){
        child = obj; 
    }

    private void alterChild(){
        if(this.child.tag.Contains("And")){
            this.child.GetComponent<AndGateLogic>().setValue(this.value); 
        }
        else if(this.child.tag.Contains("Or")){
            this.child.GetComponent<OrGateLogic>().setValue(this.value); 
        }
        else if(this.child.tag.Contains("Not")){
            this.child.GetComponent<NotGateLogic>().setValue(this.value); 
        }
        else if (this.child.tag.Contains("Result")){
            Debug.Log("Invalid Move"); 
        }
    }
}
