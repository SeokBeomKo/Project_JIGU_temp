using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataLoader : MonoBehaviour
{
    GameData[] gameDataList;
    GoogleSheetConnector googleSheet;
    JsonConnector json;

    private void Start()
    {
        json.LoadFile("Version", gameDataList[0]); // version 반환하는 함수 
        StartCoroutine(googleSheet.LoadGoogleData("A2", 0));

        
    }
}
