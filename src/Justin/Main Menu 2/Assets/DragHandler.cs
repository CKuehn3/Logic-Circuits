using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject item;
    Vector2 startPosition;
    Transform startParent; 


    public void OnBeginDrag(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left){ //Converting to left click only
        item = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
    }
       
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left){ //Converting to left click only
        item = gameObject;
        var screenPoint = (Vector3)Input.mousePosition;
        screenPoint.z = 10.0f; //distance of the plane from the camera
        transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
    }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        item = null;

        if (transform.parent != startParent)
        {
            transform.position = startPosition;
        }
    }

}