using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
	public bool value; 
    public GameObject parent; 
	
    // Start is called before the first frame update
    void Start()
    {
      gameObject.tag = "Result";    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setParent(GameObject obj){
        if(!obj.tag.Contains("Input")){
          parent = obj; 
        }
        else {
            Debug.Log("Invalid Move"); 
        }
    }

    public void setValue(bool val){
        this.value = val; 
    }
}
