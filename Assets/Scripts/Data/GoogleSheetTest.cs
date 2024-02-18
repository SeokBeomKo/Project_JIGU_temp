using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class GoogleSheetTest : MonoBehaviour
{
    public TestSO testSO;
    public const string ADDRESS = "https://docs.google.com/spreadsheets/d/1xGNPbePoOnsaKqLi-TXz-PoukBWAYeE_O_enQ0k_cxk";

    public string path;

    private void Awake() 
    {
        path = Application.persistentDataPath;

        if (!System.IO.Directory.Exists(path))
        {
            System.IO.Directory.CreateDirectory(path);
        }
    }

    IEnumerator Start() 
    {
        string URL = GetTSVAdress(ADDRESS, "B2:D");

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
            for(int j = 0; j < columnSize; j++)
            {
                if(testSO != null) 
                {
                    testSO.statsArray[i].name = column[0];
                    testSO.statsArray[i].birthday = int.Parse(column[1]);
                    testSO.statsArray[i].sex = column[2];
                }
            }
        }
    }

    public void SaveJson(string path)
    {
        string data = JsonUtility.ToJson(testSO);
        File.WriteAllText(path, data);
    }

    public void LoadJson(string path)
    {
        string data = File.ReadAllText(path);
        testSO = JsonUtility.FromJson<TestSO>(data);
    }
    
}
