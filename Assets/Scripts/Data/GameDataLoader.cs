using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataLoader : MonoBehaviour
{
    public ScriptableObject[] gameDataList;
    //public GoogleSheetConnector googleSheet;
    public JsonConnector json;

    private void Start()
    {
        /*json.LoadFile("Version", gameDataList[0]); // version ��ȯ�ϴ� �Լ� 
        StartCoroutine(googleSheet.LoadGoogleData("A2", 0)); */

        //json.SaveFile(gameDataList[0].name, (GameData<T>)gameDataList[0].SetScriptableObject("Data"));
        
    }
}
