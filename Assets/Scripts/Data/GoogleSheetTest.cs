using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleSheetTest : MonoBehaviour
{
    public readonly string ADDRESS = "https://docs.google.com/spreadsheets/d/1xGNPbePoOnsaKqLi-TXz-PoukBWAYeE_O_enQ0k_cxk";
    public readonly string RANGE = "B2:D";
    public readonly long SHEET_ID = 0;

    public TestSO testSO;

    IEnumerator Start() 
    {
        string URL = GetTSVAdress(ADDRESS, RANGE, SHEET_ID);

        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        string data = www.downloadHandler.text;
        //Debug.Log(data);
        SetSO(data);
    }

    public static string GetTSVAdress(string address, string range, long sheedID) 
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
                    Stats stat = testSO.statsArray[i];

                    stat.name = column[0];
                    stat.birthday = int.Parse(column[1]);
                    stat.sex = column[2];
                }
            }
        }
    }
}
