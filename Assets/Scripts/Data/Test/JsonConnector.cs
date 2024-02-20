using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonConnector : MonoBehaviour
{
    public void SaveFile(string fileName, GameData gameData)
    {
        string path = SetFilePath(fileName);

        string jsonData = JsonUtility.ToJson(gameData);
        File.WriteAllText(path, jsonData);
        Debug.Log("Saved data to " + path);
    }

    public void LoadFile(string fileName, GameData gameData)
    {
        string path = SetFilePath(fileName);

        if (!File.Exists(path))
        {
            Debug.Log("File does not exist : " + path);
            return;
        }

        string jsonData = File.ReadAllText(path);
        JsonUtility.FromJsonOverwrite(jsonData, gameData);
        Debug.Log("Loaded data from " + path);
    }

    private string SetFilePath(string fileName)
    {
        return Path.Combine(Application.dataPath + "/Data/", fileName + ".json");
    }
}

// Path.Combine(Application.persistentDataPath, "database.json"); <- Android