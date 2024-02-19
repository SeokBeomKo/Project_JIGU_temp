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
        string URL = GetTSVAdress(ADDRESS, "A2:D");

        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        string data = www.downloadHandler.text;
        SetSO(data);

        SaveJson(path);
    }


    public static string GetTSVAdress(string address, string range, long sheedID = 0) 
    {
        return $"{address}/export?format=tsv&range={range}&gid={sheedID}";
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
    }

    public void LoadJson(string path)
    {
        string jsonData = File.ReadAllText(path);
        testSO = JsonUtility.FromJson<TestSO>(jsonData);
    }
}
