using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/VersionData")]
public class VersionData : GameData
{
    public float version;

    public override void SetScriptableObject(string tsv)
    {
        string[] row = tsv.Split('\n');
        int rowSize = row.Length;
        int columnSize = row[0].Split('\t').Length;

        for(int i = 0; i < rowSize; i++)
        {
            string[] column = row[i].Split('\t');
            version = float.Parse(column[0]);
        }
    }

    public float GetVersionData()
    {
        return version;
    }
}
