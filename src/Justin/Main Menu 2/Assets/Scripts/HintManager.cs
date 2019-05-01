using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class HintManager : MonoBehaviour
{
    Text hintText;  
    string str; 
	int count; 

    // Start is called before the first frame update
    void Start()
    {
     count = 0;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick(){
        hintText = GameObject.Find("Hint Text").GetComponent<Text>();
        
        if(count < 3)
            count++;
        else
            count = 1;  

        hintText.text = hints(count) + "\n\n" + str; 
    }

    private string hints(int i){
        if(i == 1){
            return "Break the truth table down into smaller chunks by trying to create a solution one row at a time."; 
        } else if(i == 2){
            return "A NOT gate will return a value opposite of it's input."; 
        } else if(i == 3){
            return "The AND gate will return true only if all inputs are true."; 
        } else if(i == 4){
            return "The OR gate will return true if any one of it's inputs are true."; 
        }
        else{
            return ""; 
        }
    }

    public void createHint(string s){
        this.str = s; 
    }

    public void setRed(){
        GetComponent<Image>().color = Color.red;
    }

    public void setGray(){
        GetComponent<Image>().color = new Color(117f/255f, 128f/255f, 139f/255f); 
    }
}
