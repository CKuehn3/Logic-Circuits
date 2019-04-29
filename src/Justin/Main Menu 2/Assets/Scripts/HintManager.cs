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
        
        if(count < 4)
            count++;
        else
            count = 1;  

        hintText.text = hints(count) + "\n\n" + str; 
    }

    private string hints(int i){
        if(i == 1){
            return "This is the first hint."; 
        } else if(i == 2){
            return "This is the second hint."; 
        } else if(i == 3){
            return "This is the third hint."; 
        } else if(i == 4){
            return "This is the fourth hint."; 
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
