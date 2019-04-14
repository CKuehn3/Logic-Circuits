using UnityEngine;
using System.Collections;
public class DrawLine : MonoBehaviour 
{
    private LineRenderer line; // Reference to LineRenderer
    private Vector3 mousePos;    
    private Vector3 startPos;    // Start position of line
    private Vector3 endPos;    // End position of line
    //gameObject.tag = "Wire";
    private bool value; 

    void Update () 
    {

        // On mouse down new line will be created 
        if(Input.GetMouseButtonDown(1)) //Changing to right click for wires
        {
            if(line == null)
                createLine();
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            line.SetPosition(0,mousePos);
            startPos = mousePos;

            RaycastHit2D ray = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            if (ray){
                GameObject hitGameObject = ray.collider.gameObject;
                //Set if condition to 'andgate' tag
                if(hitGameObject.tag.Contains("And")){
                    Debug.Log("Clicked AND gate."); 
                    this.value = hitGameObject.GetComponent<AndGateLogic>().value; //Set wire value to value retrieved from clicked object
                    Debug.Log("AND: " + hitGameObject.GetComponent<AndGateLogic>().value); 
                }
                else if(hitGameObject.tag.Contains("Or")){
                    Debug.Log("Clicked OR gate."); 
                    this.value = hitGameObject.GetComponent<OrGateLogic>().value; //Set wire value to value retrieved from clicked object
                    Debug.Log("OR: " + hitGameObject.GetComponent<OrGateLogic>().value); 
                }
                else if(hitGameObject.tag.Contains("Not")){
                    Debug.Log("Clicked NOT gate."); 
                    this.value = hitGameObject.GetComponent<NotGateLogic>().value; //Set wire value to value retrieved from clicked object
                    Debug.Log("OR: " + hitGameObject.GetComponent<NotGateLogic>().value); 
                }
                else if(hitGameObject.tag.Contains("Positive")){
                    Debug.Log("Hit Test Input"); 
                    this.value = hitGameObject.GetComponent<TestPositiveInput>().value; 
                    Debug.Log("Test Input Val: " + hitGameObject.GetComponent<TestPositiveInput>().value); 
                }
                else if(hitGameObject.tag.Contains("Negative")){
                    Debug.Log("Hit Test Input"); 
                    this.value = hitGameObject.GetComponent<TestNegativeInput>().value; 
                    Debug.Log("Test Input Val: " + hitGameObject.GetComponent<TestNegativeInput>().value); 
                }

            }
        }
        else if(Input.GetMouseButtonUp(1)){ //Changing to right click for wires
    
            if(line)
            {
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0;
                line.SetPosition(1,mousePos);
                endPos = mousePos;
                addColliderToLine();
                line = null;
            }

            RaycastHit2D ray = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            if (ray){
                GameObject hitGameObject = ray.collider.gameObject;
                //Debug.Log(hitGameObject); 
                if(hitGameObject.tag.Contains("Or")){
                    Debug.Log("Released on Or gate."); 
                    hitGameObject.GetComponent<OrGateLogic>().inputs.Add(this.value); //Set receiving gate value
                    Debug.Log("OR Val: " + hitGameObject.GetComponent<OrGateLogic>().value);  
                }
                else if(hitGameObject.tag.Contains("And")){
                    Debug.Log("Released on And gate."); 
                    hitGameObject.GetComponent<AndGateLogic>().inputs.Add(this.value); //Set receiving gate value
                    Debug.Log("AND Val: " + hitGameObject.GetComponent<AndGateLogic>().value);  
                }
                else if(hitGameObject.tag.Contains("Not")){
                    Debug.Log("Released on Not gate."); 
                    hitGameObject.GetComponent<NotGateLogic>().tempVal = this.value; //Set receiving gate value
                    Debug.Log("NOT Val: " + hitGameObject.GetComponent<NotGateLogic>().value);  
                }
                else if(hitGameObject.tag.Contains("Result")){
                    Debug.Log("Released on Result."); 
                    hitGameObject.GetComponent<Result>().value = this.value; //Set receiving gate value
                    Debug.Log("RESULT Value: " + hitGameObject.GetComponent<Result>().value);  
                }

            }
        }
        else if(Input.GetMouseButton(1)) //Changing to right click for wires
        {
            if(line)
            {
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0;
                line.SetPosition(1,mousePos);
            }
        }
    }
    // Following method creates line runtime using Line Renderer component
    private void createLine()
    {
        line = new GameObject("Line").AddComponent<LineRenderer>();
        line.tag = "Wires";
        line.material =  new Material(Shader.Find("Diffuse"));
        line.SetVertexCount(2);
        line.SetWidth(0.1f,0.1f);
        line.SetColors(Color.yellow, Color.yellow);
        line.useWorldSpace = true;    
    }
    // Following method adds collider to created line
    private void addColliderToLine()
    {
        BoxCollider col = new GameObject("Collider").AddComponent<BoxCollider> ();
        col.transform.parent = line.transform; // Collider is added as child object of line
        float lineLength = Vector3.Distance (startPos, endPos); // length of line
        col.size = new Vector3 (lineLength, 0.1f, 1f); // size of collider is set where X is length of line, Y is width of line, Z will be set as per requirement
        Vector3 midPoint = (startPos + endPos)/2;
        col.transform.position = midPoint; // setting position of collider object
        // Following lines calculate the angle between startPos and endPos
        float angle = (Mathf.Abs (startPos.y - endPos.y) / Mathf.Abs (startPos.x - endPos.x));
        if((startPos.y<endPos.y && startPos.x>endPos.x) || (endPos.y<startPos.y && endPos.x>startPos.x))
        {
            angle*=-1;
        }
        angle = Mathf.Rad2Deg * Mathf.Atan (angle);
        col.transform.Rotate (0, 0, angle);
    }
}