using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class GameData<T> : ScriptableObject
{
    [Header("시트의 범위")]
    public string range;
    [Header("시트의 넘버링")]
    public long sheetID;
    [Header("저장할 Json 파일 이름")]
    public string jsonFileName;

    public abstract T SetScriptableObject(string tsv);
}
