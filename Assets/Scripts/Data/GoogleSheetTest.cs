using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleSheetTest : MonoBehaviour
{
    //const string URL = "https://docs.google.com/spreadsheets/d/1xGNPbePoOnsaKqLi-TXz-PoukBWAYeE_O_enQ0k_cxk/export?format=tsv&range=A2:B";
    public readonly string ADDRESS = "https://docs.google.com/spreadsheets/d/1xGNPbePoOnsaKqLi-TXz-PoukBWAYeE_O_enQ0k_cxk";
    public readonly string RANGE = "A2:B";
    public readonly long SHEET_ID = 0;


    IEnumerator Start() 
    {
        string URL = GetTSVAdress(ADDRESS, RANGE, SHEET_ID);

        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        string data = www.downloadHandler.text;
        Debug.Log(data);
    }

    public static string GetTSVAdress(string address, string range, long sheedID) 
    {
        return $"{address}/export?format=tsv&range={range}&gid={sheedID}";
    }
}
