using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataLoader : MonoBehaviour
{
    public GameData[] gameDataList;
    //public GoogleSheetConnector googleSheet;
    public JsonConnector json;

    private void Start()
    {
        /*json.LoadFile("Version", gameDataList[0]); // version 반환하는 함수 
        StartCoroutine(googleSheet.LoadGoogleData("A2", 0)); */

        // json.SaveFile(gameDataList[0].name, (GameData<T>)gameDataList[0].SetScriptableObject("Data"));

        // SetScriptableObject 함수 호출 및 TSV 데이터 전달
        //json.SaveFile(gameDataList[0].name, gameDataList[0].SetScriptableObject("test"));
        //json.SaveFile(gameDataList[1].name, gameDataList[1].SetScriptableObject("test"));

        json.LoadFile(gameDataList[1].name, gameDataList[1].SetScriptableObject("test"));
        gameDataList[1].DebugSO();
    }
}
