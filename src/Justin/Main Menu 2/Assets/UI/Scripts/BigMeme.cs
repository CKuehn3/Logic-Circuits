using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BigMeme : MonoBehaviour
{
    private bool in1;
    private bool in2;
    private bool outWire;
    private Vector3 position;
    private bool found;
    public LineRenderer linesBoi;
    //public Transform gate;
    private GameObject currentGO;
    private Vector3 vec = Vector3.zero;
    public String targetTag = "Gates";
    // Start is called before the first frame update
    void Start()
    {
        found = false;

    }

    public void OnMouseOver()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (TestHit() && Input.GetMouseButtonUp(1) && found == false)
        {
            vec.x = Input.mousePosition.x;
            vec.y = Screen.height - Input.mousePosition.y;
            TestHit();
            if (TestHit() && in1 == false)
            {
                position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                linesBoi.SetPosition(1, position);
                //gate.SetSiblingIndex(1);
                in1 = true;
            }
            else if (TestHit() && in2 == false)
            {
                position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                linesBoi.SetPosition(1, position);
                //gate.SetSiblingIndex(2);
                in2 = true;
            }
            found = true;
        }
        if (TestHit() && Input.GetMouseButtonDown(1) && found == false)
        {
            vec.x = Input.mousePosition.x;
            vec.y = Screen.height - Input.mousePosition.y;
            if (TestHit() && outWire == false)
            {
                linesBoi = Instantiate(linesBoi);
                position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                linesBoi.SetPosition(0, position);
                //gate.SetSiblingIndex(0);
                outWire = true;
            }
        }
    }

    private bool TestHit()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); ;
        RaycastHit hit = new RaycastHit();
        bool hehe = false;
        if (Physics.Raycast(ray, out hit))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                currentGO = hit.collider.gameObject;
                hehe = true;
            }
        }
        else
        {
            hehe = false;
        }
        return hehe;
    }
}
