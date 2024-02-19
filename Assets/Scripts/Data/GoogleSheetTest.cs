using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class GoogleSheetTest : MonoBehaviour
{
    public TestSO testSO;
    public const string ADDRESS = "https://docs.google.com/spreadsheets/d/1xGNPbePoOnsaKqLi-TXz-PoukBWAYeE_O_enQ0k_cxk";
    string path;

    private void Awake()
    {
        path = Path.Combine(Application.dataPath + "/Data/", "testData.json");
        // Path.Combine(Application.persistentDataPath, "database.json"); <- 안드로이드용
    }

    IEnumerator Start() 
    {
        LoadJson(path);

        string URL = GetTSVAdress(ADDRESS, "A2:D");
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();
        string data = www.downloadHandler.text;

        if (GetVersion(data) != testSO.version || !File.Exists(path)) // 버전이 다르거나 Json 파일이 없을 때
        {
            SetSO(data);
            SaveJson(path);
        }

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            SaveJson(path);
        }

        if(Input.GetKeyDown(KeyCode.M))
        {
            LoadJson(path);
        }
    }


    public static string GetTSVAdress(string address, string range, long sheedID = 0) 
    {
        return $"{address}/export?format=tsv&range={range}&gid={sheedID}";
    }

    private float GetVersion(string tsv)
    {
        string[] row = tsv.Split('\n');
        return float.Parse(row[0].Split('\t')[0]);
    }

    private void SetSO(string tsv)
    {
        string[] row = tsv.Split('\n');
        int rowSize = row.Length;
        int columnSize = row[0].Split('\t').Length; 

        for(int i = 0; i < rowSize; i++)
        {
            string[] column = row[i].Split('\t');
            if(i == 0)
            {
                testSO.version = float.Parse(column[0]);
            }

            for(int j = 1; j < columnSize; j++)
            {
                testSO.statsArray[i].name = column[1];
                testSO.statsArray[i].birthday = int.Parse(column[2]);
                testSO.statsArray[i].sex = column[3];
            }
        }
    }

    public void SaveJson(string path)
    {
        string jsonData = JsonUtility.ToJson(testSO);
        File.WriteAllText(path, jsonData);
        Debug.Log("Saved data to " + path);
    }

    public void LoadJson(string path)
    {
        if (!File.Exists(path))
        {
            Debug.Log("File does not exist : " + path);
            return;
        }

        string jsonData = File.ReadAllText(path);
        JsonUtility.FromJsonOverwrite(jsonData, testSO);
        Debug.Log("Loaded data from " + path);
    }
}
