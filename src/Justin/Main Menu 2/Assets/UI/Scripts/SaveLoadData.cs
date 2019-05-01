using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//https://www.youtube.com/watch?v=XOjd_qU2Ido Big shout out to them for the walkthrough
[System.Serializable]
public class SaveLoadData
{
    public int[] gaterinos; //gaws = Gates And Wires
    public float[] xPositions;
    public float[] yPositions;
    public float[] zPositions;
    //public int score;
    public SaveLoadData(int[] gates, float[] xs, float[] ys, float[] zs)
    {
        gaterinos = gates;
        xPositions = xs;
        yPositions = ys;
        zPositions = zs;
        Debug.Log("SaveLoadData made");
    }
}
