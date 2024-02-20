using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonConnector : MonoBehaviour
{
    public void SaveFile(string fileName, object SO)
    {
        string path = SetFilePath(fileName);

        string jsonData = JsonUtility.ToJson(SO);
        File.WriteAllText(path, jsonData);
        Debug.Log("Saved data to " + path);
    }

    public void LoadFile(string fileName, object SO)
    {
        string path = SetFilePath(fileName);

        if (!File.Exists(path))
        {
            Debug.Log("File does not exist : " + path);
            return;
        }

        string jsonData = File.ReadAllText(path);
        JsonUtility.FromJsonOverwrite(jsonData, SO);
        Debug.Log("Loaded data from " + path);
        Debug.Log(SO);
    }

    private string SetFilePath(string fileName)
    {
        return Path.Combine(Application.dataPath + "/Data/", fileName + ".json");
    }
}

// Path.Combine(Application.persistentDataPath, "database.json"); <- Android