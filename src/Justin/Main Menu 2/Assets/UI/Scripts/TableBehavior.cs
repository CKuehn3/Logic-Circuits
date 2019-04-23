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
            {"F","F","F", "T"},
            {"F","F","T", "T"},
            {"F","T","F", "T"},
            {"F","T","T", "F"},
            {"T","F","F", "F"},
            {"T","F","T", "F"},
            {"T","T","F", "F"},
            {"T","T","T", "F"}
        };
        int Variables = 3;
        int Rows = 8;
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
        int Rows = 8;
        int Variable = 3;
        GameObject inputx = GameObject.Find("Input X");
        GameObject inputy = GameObject.Find("Input Y");
        GameObject inputz = GameObject.Find("Input Z");
        GameObject result = GameObject.Find("Result");
        for (int i = 0; i < (Rows); i++)
        {
            GameObject Current = GameObject.Find("TruthTable" +
                "/TableData/TableDataItem(" + i + ")");
            Debug.Log("Current: " + Current);
            GameObject Xval = GameObject.Find("TruthTable" +
                "/TableData/TableDataItem(" + i + ")" +
                "/ToF(" + 0 + ")");
            GameObject Yval = GameObject.Find("TruthTable" +
                "/TableData/TableDataItem(" + i + ")" +
                "/ToF(" + 1 + ")");
            GameObject Zval = GameObject.Find("TruthTable" +
                "/TableData/TableDataItem(" + i + ")" +
                "/ToF(" + 2 + ")");
            GameObject resultText = GameObject.Find("TruthTable" +
                "/TableData/TableDataItem(" + i + ")" +
                "/ToF(" + Variable + ")");

            inputx.GetComponent<TestPositiveInput>().setValue(StringtoBool(Xval.GetComponent<Text>().text));
            Debug.Log("X value Set to " + StringtoBool(Xval.GetComponent<Text>().text));
            inputy.GetComponent<TestPositiveInput>().setValue(StringtoBool(Yval.GetComponent<Text>().text));
            Debug.Log("Y value Set to " + StringtoBool(Yval.GetComponent<Text>().text));
            inputz.GetComponent<TestPositiveInput>().setValue(StringtoBool(Zval.GetComponent<Text>().text));
            Debug.Log("Z value Set to " + StringtoBool(Zval.GetComponent<Text>().text));

            if (StringtoBool(resultText.GetComponent<Text>().text) == result.GetComponent<Result>().value)
                {
                    Current.GetComponent<Image>().color = new Color32(0, 255, 0, 50);
                Debug.Log(resultText.GetComponent<Text>().text + " = " + result.GetComponent<Result>().value);
                }
                else { Current.GetComponent<Image>().color = new Color32(255, 0, 0, 50); Debug.Log(resultText.GetComponent<Text>().text + " != " + result.GetComponent<Result>().value); }
                
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
