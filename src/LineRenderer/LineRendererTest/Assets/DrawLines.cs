using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLines : MonoBehaviour
{
    [SerializeField]
    private GameObject lineGeneratorPrefab;
    [SerializeField]
    private GameObject linePointPrefab;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPos.z = 0;

            CreatePointMarker(newPos);
        }
        if (Input.GetMouseButtonDown(1))
        {
            ClearAllPoints();
        }
        if (Input.GetKeyDown("e"))
        {
            GenerateNewLine();
        }
    }

    private void CreatePointMarker(Vector3 pointPosition)
    {
        Instantiate(linePointPrefab, pointPosition, Quaternion.identity);
    }

    private void ClearAllPoints()
    {
        GameObject[] allPoints = GameObject.FindGameObjectsWithTag("PointMarker");
        
        foreach (GameObject point in allPoints)
        {
            Destroy(point);
        }
    }

    private void GenerateNewLine()
    {
        GameObject[] allPoints = GameObject.FindGameObjectsWithTag("PointMarker");
        Vector3[] allPointPositions = new Vector3[allPoints.Length];

        if(allPoints.Length >= 2)
        {
            for (int i = 0; i < allPoints.Length; i++)
            {
                allPointPositions[i] = allPoints[i].transform.position;
            }
            SpawnLineGenerator(allPointPositions);
        }
        else
        {
            Debug.Log("Need 2 or more points to create a line.");
        }
    }
    private void SpawnLineGenerator(Vector3[] linePoints)
    {
        GameObject newLineGen = Instantiate(lineGeneratorPrefab);
        LineRenderer lrend = newLineGen.GetComponent<LineRenderer>();

        lrend.positionCount = linePoints.Length;
        lrend.SetPositions(linePoints);
        
        Destroy(newLineGen, 5);
    }

}
