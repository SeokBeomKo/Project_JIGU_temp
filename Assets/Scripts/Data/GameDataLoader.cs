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
        /*json.LoadFile("Version", gameDataList[0]); // version ��ȯ�ϴ� �Լ� 
        StartCoroutine(googleSheet.LoadGoogleData("A2", 0)); */

        // json.SaveFile(gameDataList[0].name, (GameData<T>)gameDataList[0].SetScriptableObject("Data"));

        // SetScriptableObject �Լ� ȣ�� �� TSV ������ ����
        //json.SaveFile(gameDataList[0].name, gameDataList[0].SetScriptableObject("test"));
        //json.SaveFile(gameDataList[1].name, gameDataList[1].SetScriptableObject("test"));

        json.LoadFile(gameDataList[1].name, gameDataList[1].SetScriptableObject("test"));
        gameDataList[1].DebugSO();
    }
}
