using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableBehavior : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        string[,] items = new string[,]
        {
            {"X","Y","Z","A"},
            {"T","T","T", "T"},
            {"T","T","F", "T"},
            {"F","F","T", "F"},
            {"F","T","F", "F"},
            {"F","F","F", "T"}
        };
        int Variables = 3;
        int Rows = 5;
        GameObject Header = GameObject.Find("TableHead");
        GameObject HeaderItem = GameObject.Find("TableItem(0)");
        GameObject TableArea = GameObject.Find("TableData");
        GameObject Row = GameObject.Find("TableDataItem(0)");
        GameObject TrueorFalse = GameObject.Find("ToF(0)");
        Vector3 CurrentVector = Row.transform.position;


        for (int i = 1; i < (Variables + 1); i++) {
            GameObject NewHeaderItem = Instantiate(HeaderItem,Header.transform);
            NewHeaderItem.name = "TableItem(" + i + ")";
        }
        for (int i = 1; i < (Variables + 1); i++)
        {
            GameObject NewToF = Instantiate(TrueorFalse, Row.transform);
            NewToF.name = "ToF("+ i + ")";
        }
        for (int i = 1; i < (Rows); i++)
        {
            CurrentVector = new Vector3(CurrentVector.x, CurrentVector.y - (float)(.775));
            GameObject NewRow = Instantiate(Row, CurrentVector, Quaternion.identity , TableArea.transform);
            NewRow.name = "TableDataItem("+ i +")";
        }
        for (int i = 0; i < (Variables + 1); i++) {
            GameObject Current = GameObject.Find("TableItem(" + i + ")");
            Current.GetComponent<Text>().text = items[0,i];
        }
        for (int i = 0; i < (Rows); i++)
        {
            for (int j = 0; j < (Variables + 1); j++) {
                GameObject Current = GameObject.Find("TruthTable" +
                    "/TableData/TableDataItem(" + i + ")" +
                    "/ToF(" + j + ")");
                Current.GetComponent<Text>().text = items[i+1, j];
            }
        }
      }
    private bool StringtoBool(string s) {
        if (s == "T") { return true; }
        else { return false; }
    }
    
    public void Check() {
        int Rows = 5;
        int Variable = 3;
        for (int i = 0; i < (Rows); i++)
        {
            GameObject Current = GameObject.Find("TruthTable" +
                "/TableData/TableDataItem(" + i + ")");
            Debug.Log("Current: " + Current); 
            GameObject Text = GameObject.Find("TruthTable" +
                "/TableData/TableDataItem(" + i + ")" +
                "/ToF(" + Variable + ")");

            if (StringtoBool(Text.GetComponent<Text>().text))// == vairable location
            {
                Current.GetComponent<Image>().color = new Color32(0, 255, 0, 50);
            }
            else { Current.GetComponent<Image>().color = new Color32(255, 0, 0, 50); }
    
    
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
