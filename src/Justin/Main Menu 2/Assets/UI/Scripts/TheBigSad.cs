using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TheBigSad : MonoBehaviour
{
    private static GameObject[] allGates;
    public GameObject andGate;
    public GameObject orGate;
    public GameObject notGate;

    //public GameObject[] gaterinos;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        allGates = FindGameObjectsWithTags(new string[] { "Gates And", "Gates Or", "Gates Not"});
    }

    public void save()
    {
        SaveLoad.Save(allGates);
    }

    public void load()
    {
        SaveLoadData file = SaveLoad.Load();
        for (int i = 0; i < allGates.Length; i++)
        {
            GameObject gate = new GameObject();
            if (file.gaterinos[i] == 1)
            {
                gate = andGate;
            }
            else if (file.gaterinos[i] == 2)
            {
                gate = orGate;
            }
            else if (file.gaterinos[i] == 3)
            {
                gate = notGate;
            }

            Vector3 pos;
            pos.x = file.xPositions[i];
            pos.y = file.yPositions[i];
            pos.z = file.zPositions[i];

            GameObject objectInstance = Instantiate(gate, pos, Quaternion.Euler(new Vector3(0, 0, 0)));
        }
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
