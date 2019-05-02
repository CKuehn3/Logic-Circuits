using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class TableBehavior : MonoBehaviour
{
    //[SerializeField]
    //private int minGates;
    //[SerializeField]
    //private GameObject canvas;
    [SerializeField]
    private GameObject canvas;
    private Transform canvasT;
    public static bool solved;
    private void Awake()
    {
        //display(canvas, false);
    }
    // Start is called before the first frame update
    void Start()
    {
        //canvas = GameObject.Find("Score");
        //canvasT = canvas.transform;
        //GameObject button = canvasT.GetChild(0).GetChild(2).gameObject;
        //button.SetActive(false);
        solved = false;
        canvas.SetActive(false);
        string[,] items = new string[0,0];
        GameObject Level = GameObject.Find("Play Area" +
                "/Text");
        int lv = 0;
        Debug.Log(Level.GetComponent<Text>().text);
        switch (Level.GetComponent<Text>().text) {
            case "LEVEL 1":
                lv = 1;
                break;
            case "LEVEL 2":
                lv = 2;
                break;
            case "LEVEL 3":
                lv = 3;
                break;
            case "LEVEL 4":
                lv = 4;
                break;
        }
        Debug.Log(lv);
        //canvas.GetComponent<CanvasGroup>().alpha = 0.0f;
        //minGates = 3;
        switch (lv){
            case 1:
                items = new string[,]
                {
            {"X","Y","A"},
            {"T","T", "T"},
            {"T","F", "F"},
            {"F","T", "F"},
            {"F","F", "F"}
                };
                break;
            case 2:
                items = new string[,]
                {
            {"X","Y","A"},
            {"T","T", "T"},
            {"T","F", "T"},
            {"F","T", "T"},
            {"F","F", "F"}
                };
                break;
            case 3:
                items = new string[,]
                {
            {"X","Y","Z","A"},
            {"T","T","T", "F"},
            {"T","T","F", "F"},           
            {"T","F","T", "F"},
            {"T","F","F", "T"},
            {"F","T","T", "F"},
            {"F","T","F", "T"},
            {"F","F","T", "F"},
            {"F","F","F", "T"}
                };
                break;
            case 4:
            items = new string[,]
            {
            {"X","Y","Z","A"},
            {"T","T","T", "F"},
            {"T","T","F", "T"},
            {"T","F","T", "F"},
            {"T","F","F", "T"},
            {"F","T","T", "F"},
            {"F","T","F", "T"},
            {"F","F","T", "F"},
            {"F","F","F", "F"}
            };
            break;
        }
        int Variables = items.GetLength(1) - 1;
        Debug.Log(Variables);
        int Rows = items.GetLength(0) - 1;
        Debug.Log(Rows);
        GameObject Header = GameObject.Find("TableHead");
        GameObject HeaderItem = GameObject.Find("TableItem(0)");
        GameObject TableArea = GameObject.Find("TableData");
        GameObject Row = GameObject.Find("TableDataItem(0)");
        GameObject TrueorFalse = GameObject.Find("ToF(0)");
        Vector3 CurrentVector = Row.transform.position;


        for (int i = 1; i < (Variables + 1); i++)
        {
            GameObject NewHeaderItem = Instantiate(HeaderItem, Header.transform);
            NewHeaderItem.name = "TableItem(" + i + ")";
        }
        for (int i = 1; i < (Variables + 1); i++)
        {
            GameObject NewToF = Instantiate(TrueorFalse, Row.transform);
            NewToF.name = "ToF(" + i + ")";
        }
        for (int i = 1; i < (Rows); i++)
        {
            CurrentVector = new Vector3(CurrentVector.x, CurrentVector.y - (float)(.775));
            GameObject NewRow = Instantiate(Row, CurrentVector, Quaternion.identity, TableArea.transform);
            NewRow.name = "TableDataItem(" + i + ")";
        }
        for (int i = 0; i < (Variables + 1); i++)
        {
            GameObject Current = GameObject.Find("TableItem(" + i + ")");
            Current.GetComponent<Text>().text = items[0, i];
        }
        for (int i = 0; i < (Rows); i++)
        {
            for (int j = 0; j < (Variables + 1); j++)
            {
                GameObject Current = GameObject.Find("TruthTable" +
                    "/TableData/TableDataItem(" + i + ")" +
                    "/ToF(" + j + ")");
                Current.GetComponent<Text>().text = items[i + 1, j];
            }
        }
    }
    private bool StringtoBool(string s)
    {
        if (s == "T") { return true; }
        else { return false; }
    }

    public void Check(int min)
    {

        string[,] items = new string[0, 0];
        GameObject Level = GameObject.Find("Play Area" +
                "/Text");
        int lv = 0;
        int minGates = 0;
        Debug.Log(Level.GetComponent<Text>().text);
        switch (Level.GetComponent<Text>().text)
        {
            case "LEVEL 1":
                lv = 1;
                minGates = 1;
                break;
            case "LEVEL 2":
                lv = 2;
                minGates = 1;
                break;
            case "LEVEL 3":
                lv = 3;
                minGates = 3;
                break;
            case "LEVEL 4":
                lv = 4;
                minGates = 4;
                break;
        }
        Debug.Log(lv);
        switch (lv)
        {
            case 1:
                items = new string[,]
                {
            {"X","Y","A"},
            {"T","T", "T"},
            {"T","F", "F"},
            {"F","T", "F"},
            {"F","F", "F"}
                };
                break;
            case 2:
                items = new string[,]
                {
            {"X","Y","A"},
            {"T","T", "T"},
            {"T","F", "T"},
            {"F","T", "T"},
            {"T","T", "F"}
                };
                break;
            case 3:
                items = new string[,]
                {
            {"X","Y","Z","A"},
            {"F","F","F", "T"},
            {"F","F","T", "F"},
            {"F","T","F", "T"},
            {"F","T","T", "F"},
            {"T","F","F", "T"},
            {"T","F","T", "F"},
            {"T","T","F", "F"},
            {"T","T","T", "F"}
                };
                break;
            case 4:
                items = new string[,]
                {
            {"X","Y","Z","A"},
            {"T","T","T", "F"},
            {"T","T","F", "T"},
            {"T","F","T", "F"},
            {"T","F","F", "T"},
            {"F","T","T", "F"},
            {"F","T","F", "T"},
            {"F","F","T", "F"},
            {"F","F","F", "F"}
                };
                break;
        }
        int Variable = items.GetLength(1) - 1;
        Debug.Log(Variable);
        int Rows = items.GetLength(0) - 1;
        Debug.Log(Rows);
        int count = 0;
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
            if (Variable >= 3)
            {
                inputz.GetComponent<TestPositiveInput>().setValue(StringtoBool(Zval.GetComponent<Text>().text));
                Debug.Log("Z value Set to " + StringtoBool(Zval.GetComponent<Text>().text));
            }
            Debug.Log("RESULTTEXT Row " + i + ": " + StringtoBool(resultText.GetComponent<Text>().text));
            Debug.Log("RESULT Row " + i + ": " + result.GetComponent<Result>().value);

            if (StringtoBool(resultText.GetComponent<Text>().text) == result.GetComponent<Result>().value)
            {
                count++;
                Current.GetComponent<Image>().color = new Color32(0, 255, 0, 50);
                Debug.Log(resultText.GetComponent<Text>().text + " = " + result.GetComponent<Result>().value);
            }
            else { Current.GetComponent<Image>().color = new Color32(255, 0, 0, 50); Debug.Log(resultText.GetComponent<Text>().text + " != " + result.GetComponent<Result>().value); }
            if (count == Rows)
            {
                //canvas = GameObject.Find("Score");
                canvas = GameObject.Find("Score Screen");
                
                canvas.SetActive(true);
                canvasT = canvas.transform;
                Debug.Log("CHILDREN:    " + canvasT.childCount);
                canvasT.GetChild(0).gameObject.SetActive(true);
                //GameObject button = canvasT.GetChild(0).GetChild(2).gameObject;
                //button.SetActive(true);
                solved = true;
                GameObject[] gates = FindGameObjectsWithTags(new string[] { "Gates And", "Gates Or", "Gates Not" });
                Debug.Log("CHASE ADDED THIS");
                Debug.Log(minGates);
                Debug.Log("Number of gates: " + gates.Length);
                //Debug.Log(minGates);
                Debug.Log("Score: " + Math.Floor((float)minGates / gates.Length * 1000));

                Text text = canvasT.GetChild(0).GetChild(0).GetChild(1).gameObject.GetComponent<Text>();
                text.text = "" + (Math.Floor((float)minGates / gates.Length * 1000)) + "/1000";
                count = 0;
                //canvas.GetComponent<CanvasGroup>().alpha = 1f;
                //display(canvas,true);
            }

            //Reset Gate Values for next loop
            inputx.GetComponent<TestPositiveInput>().onReset();
            inputy.GetComponent<TestPositiveInput>().onReset();
            if (Variable >= 3)
            {
                inputz.GetComponent<TestPositiveInput>().onReset();
            }
        }



    }
    void display(GameObject c, bool t)
    {
        // GameObject canvas = GameObject.FindObjectWithTag("ScoreCanvas");
        //GameObject canvas = GameObject.Find("Score");
        c.SetActive(t);
    }

    // Update is called once per frame
    void Update()
    {

    }
    GameObject[] FindGameObjectsWithTags(params string[] tags)
    {
        var all = new List<GameObject>();

        foreach (string tag in tags)
        {
            var temp = GameObject.FindGameObjectsWithTag(tag).ToList();
            all = all.Concat(temp).ToList();
        }

        return all.ToArray();
    }
}
