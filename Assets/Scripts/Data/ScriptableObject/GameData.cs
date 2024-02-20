using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class GameData : ScriptableObject
{
    [Header("��Ʈ�� ����")]
    public string range;
    [Header("��Ʈ�� �ѹ���")]
    public long sheetID;
    [Header("������ Json ���� �̸�")]
    public string jsonFileName;

    public abstract object SetScriptableObject(string tsv);

    public virtual void DebugSO() { }
}
