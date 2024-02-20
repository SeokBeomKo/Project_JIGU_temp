using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameData : ScriptableObject
{
    public string range;
    public long sheetID;
    public string jsonFileName;

    public abstract void SetScriptable(string tsv);
}
