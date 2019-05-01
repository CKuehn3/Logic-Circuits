using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoad
{ 
    public static void Save(GameObject[] allGates)
    {
        int[] gates = new int[allGates.Length];
        float[] xs = new float[allGates.Length];
        float[] ys = new float[allGates.Length];
        float[] zs = new float[allGates.Length];
        for (int i = 0; i < allGates.Length; i++)
        {
            if (allGates[i].tag == "Gates And")
            {
                gates[i] = 1;
                Debug.Log("Got an and gate");
            }
            else if (allGates[i].tag == "Gates Or")
            {
                gates[i] = 2;
                Debug.Log("Got an or gate");
            }
            else if (allGates[i].tag == "Gates Not")
            {
                gates[i] = 3;
                Debug.Log("Got a not gate");
            }
            else
            {
                Debug.LogError("Not a valid gate type at SaveLoad");
            }

            xs[i] = allGates[i].transform.position.x;
            ys[i] = allGates[i].transform.position.y;
            zs[i] = allGates[i].transform.position.z;
        }
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/WiredTruthSaveData.sad";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveLoadData file = new SaveLoadData(gates, xs, ys, zs);
        formatter.Serialize(stream, file);
        stream.Close();
    }



    public static SaveLoadData Load()
    {
        string path = Application.persistentDataPath + "/WiredTruthSaveData.sad";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveLoadData file = formatter.Deserialize(stream) as SaveLoadData;
            stream.Close();

            return file;
        }
        else 
        {
            Debug.LogError("Where's the giant Mansley?!" + path);
            return null;
        }

    }


}
