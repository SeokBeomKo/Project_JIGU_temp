using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class GameData<T> : ScriptableObject
{
    [Header("��Ʈ�� ����")]
    public string range;
    [Header("��Ʈ�� �ѹ���")]
    public long sheetID;
    [Header("������ Json ���� �̸�")]
    public string jsonFileName;

    public abstract T SetScriptableObject(string tsv);
}
