using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct _VersionData
{
    public float version;
}

[CreateAssetMenu(menuName = "Data/VersionData")]
public class VersionData : GameData
{ 
    public _VersionData version;

    public override object SetScriptableObject(string tsv)
    {
        //string[] row = tsv.Split('\n');
        //int rowSize = row.Length;
        //int columnSize = row[0].Split('\t').Length;

        //for(int i = 0; i < rowSize; i++)
        //{
        //    string[] column = row[i].Split('\t');
        //    version = float.Parse(column[0]);
        //}

        return version;
    }
}
