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
    public GameObject passingObject; 

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

                passingObject = ray.collider.gameObject;

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

                if(hitGameObject.tag.Contains("Or")){
                    hitGameObject.GetComponent<OrGateLogic>().setParent(passingObject); 
                    Debug.Log("Parent: " + hitGameObject.GetComponent<OrGateLogic>().parent); 
                }
                else if(hitGameObject.tag.Contains("And")){
                    hitGameObject.GetComponent<AndGateLogic>().setParent(passingObject); 
                    Debug.Log("Parent: " + hitGameObject.GetComponent<AndGateLogic>().parent); 
                }
                else if(hitGameObject.tag.Contains("Not")){
                    hitGameObject.GetComponent<NotGateLogic>().setParent(passingObject); 
                    Debug.Log("Parent: " + hitGameObject.GetComponent<NotGateLogic>().parent); 
                }
                else if(hitGameObject.tag.Contains("Result")){
                    hitGameObject.GetComponent<Result>().setParent(passingObject); 
                    Debug.Log("Parent: " + hitGameObject.GetComponent<Result>().parent); 
                }
                setPassingObjectChild(hitGameObject); 
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
        //line.SetColors(Color.yellow, Color.yellow);
        line.useWorldSpace = true;    
        line.sortingLayerName = "background"; 
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

    private void setPassingObjectChild(GameObject childObj){
         if(this.passingObject.tag.Contains("And")){
             this.passingObject.GetComponent<AndGateLogic>().setChild(childObj);
          }
        else if(this.passingObject.tag.Contains("Or")){
            this.passingObject.GetComponent<OrGateLogic>().setChild(childObj);
         }
        else if(this.passingObject.tag.Contains("Not")){
            this.passingObject.GetComponent<NotGateLogic>().setChild(childObj);
        }
        else if(this.passingObject.tag.Contains("Positive")){
            this.passingObject.GetComponent<TestPositiveInput>().setChild(childObj);
        }            
    }
}