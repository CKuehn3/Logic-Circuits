using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotGateLogic : MonoBehaviour
{
	public bool value; 
	//public List<bool> inputs = new List<bool>(); 
    public bool tempVal; 
	public GameObject child = null; 
    public GameObject parent = null; 
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Gates Not";
    }

    // Update is called once per frame
    void Update()
    {
      //calculateGateValue();    
    }

    public void reset(){
        if(this.child.tag.Contains("And")){
            this.child.GetComponent<AndGateLogic>().reset(); 
        }
        else if(this.child.tag.Contains("Or")){
            this.child.GetComponent<OrGateLogic>().reset(); 
        }
        else if(this.child.tag.Contains("Not")){
            this.child.GetComponent<NotGateLogic>().reset(); 
        }
    }

    void calculateGateValue(){

        value = !tempVal;
    }

    public void setParent(GameObject obj){
        parent = obj; 
    }
    
    public void setChild(GameObject obj){
        child = obj; 
    }

    public void setValue(bool val){
        this.tempVal = val; 
        calculateGateValue(); 
        if(child != null){
            alterChild(); 
        }
        Debug.Log("Not Value: " + this.value);
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
            this.child.GetComponent<Result>().setValue(this.value); 
        }

    }
}
