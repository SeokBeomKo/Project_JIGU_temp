using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleSheetConnector : MonoBehaviour
{
    public const string baseAddress = "https://docs.google.com/spreadsheets/d/1nEMMqBP4vUj9vt2tmw5d5_yJQw_p5tS096BvNCqwQU8";

    public IEnumerator LoadGoogleSheetData(string range, long sheetID)
    {
        string URL = GetGoogleAddress(range, sheetID);
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();
        string data = www.downloadHandler.text;
    } 

    private static string GetGoogleAddress(string range, long sheetID)
    {
        return $"{baseAddress}/export?format=tsv&range={range}&gid={sheetID}";
    }
}
