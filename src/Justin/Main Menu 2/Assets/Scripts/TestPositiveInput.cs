using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class TestPositiveInput : MonoBehaviour
{
	public bool value; 
    GameObject child; 
    GameObject hintBtn; 

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Input Positive";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onReset(){
        try{
            if(this.child.tag.Contains("And")){
                this.child.GetComponent<AndGateLogic>().reset(); 
            }
            else if(this.child.tag.Contains("Or")){
                this.child.GetComponent<OrGateLogic>().reset(); 
            }
            else if(this.child.tag.Contains("Not")){
                this.child.GetComponent<NotGateLogic>().reset(); 
            }

        }catch(Exception e){
            hintBtn = GameObject.Find("Hint"); 
            hintBtn.GetComponent<HintManager>().createHint("Make sure you use ALL inputs in your circuit."); 
            Debug.Log("Added Hint"); 
            hintBtn.GetComponent<HintManager>().setRed(); 
        }
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
        try{
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
        } catch(Exception e){
            hintBtn = GameObject.Find("Hint"); 
            hintBtn.GetComponent<HintManager>().createHint("Make sure you use ALL inputs in your circuit."); 
            Debug.Log("Added Hint"); 
            hintBtn.GetComponent<HintManager>().setRed(); 
            }
    }
}
