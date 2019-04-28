using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrGateLogic : MonoBehaviour
{
	public bool value; 
	public List<bool> inputs = new List<bool>(); 
    public GameObject child = null; 
   // public GameObject parent = null; 
    public List<GameObject> parent = new List<GameObject>(); 
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Gates Or";
        clearList(); 
    }

    // Update is called once per frame
    void Update()
    {
        //calculateGateValue(); 
    }

    public void reset(){
        clearList(); 
        Debug.Log("In Reset Method. Gate Cnt: " + inputs.Count); 
        if(this.child.tag.Contains("And")){
            this.child.GetComponent<AndGateLogic>().reset(); 
        }
        else if(this.child.tag.Contains("Or")){
            this.child.GetComponent<OrGateLogic>().reset(); 
            Debug.Log("And gate calling Or set value()"); 
        }
        if(this.child.tag.Contains("Not")){
            this.child.GetComponent<NotGateLogic>().reset(); 
        }
    }

    void calculateGateValue(){
        bool tempVal = false; 
        //Debug.Log("Or List Count: " + inputs.Count); 
        foreach(bool val in inputs){
            Debug.Log("Val: " + val); 
            if(val){
                tempVal = true; 
            }
        }

        this.value = tempVal; 
    }

    public void setParent(GameObject obj){
        parent.Add(obj);  
    }

    public void setChild(GameObject obj){
        child = obj; 
    }

    public void setValue(bool val){
        //Debug.Log("Or Count: " + inputs.Count); 
        this.inputs.Add(val); 
        Debug.Log("Or Gate Added"); 
        if(child != null && parent.Count == inputs.Count){
            calculateGateValue(); 
            alterChild(); 
        }
        Debug.Log("Or Gate Value: " + this.value); 
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

    private void clearList(){
        this.inputs.Clear(); 
    }
}
