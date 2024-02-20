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
        json.LoadFile("Version", gameDataList[0]); // version ��ȯ�ϴ� �Լ� 
        StartCoroutine(googleSheet.LoadGoogleData("A2", 0));

        
    }
}
