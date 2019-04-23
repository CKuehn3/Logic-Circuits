using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndGateLogic : MonoBehaviour
{
	public bool value; 
    public List<bool> inputs = new List<bool>(); 
    public GameObject child = null; 
    //public GameObject parent = null; 
    public List<GameObject> parent = new List<GameObject>(); 

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Gates And";
    }

    // Update is called once per frame
    void Update()
    {
        //calculateGateValue(); 
    }

    public void reset(){
        this.inputs.Clear(); 

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
        bool tempVal = true; 
        foreach(bool val in inputs){
            if(!val){
                tempVal = false; 
            }
        }

        this.value = tempVal; 
    }

    public void setParent(GameObject obj){
        //parent = obj;
        parent.Add(obj);  
    }

    public void setChild(GameObject obj){
        child = obj; 
    }

    public void setValue(bool val){
        this.inputs.Add(val); 
        calculateGateValue(); 
        Debug.Log("And Gate Value: " + this.value); 
        if(child != null && parent.Count == inputs.Count){
            alterChild(); 
        }

    }

    private void alterChild(){
        if(this.child.tag.Contains("And")){
            this.child.GetComponent<AndGateLogic>().setValue(this.value); 
        }
        else if(this.child.tag.Contains("Or")){
            this.child.GetComponent<OrGateLogic>().setValue(this.value); 
            //Debug.Log("And gate calling Or set value()"); 
        }
        else if(this.child.tag.Contains("Not")){
            this.child.GetComponent<NotGateLogic>().setValue(this.value); 
        }
        else if (this.child.tag.Contains("Result")){
            this.child.GetComponent<Result>().setValue(this.value); 
        }

    }
}
