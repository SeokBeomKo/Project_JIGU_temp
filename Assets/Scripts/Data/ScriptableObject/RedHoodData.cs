using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Data
{
    public int      level;
    public float    attackPower;
    public float    attackSpeed;
    public int      health;
    public float    moveSpeed;
    public float    maxMoveSpeed;
    public float    jumpPower;
    public float    criticalProbability;
    public float    criticalDamage;
    public float    wallSlideSpeed;
    public Vector2  wallJumpPower;
}


[CreateAssetMenu(menuName = "Data/RedHoodData")]
public class RedHoodData : GameData
{
    public Data redHood;

    public override object SetScriptableObject(string tsv)
    {
        //string[] row = tsv.Split('\n');
        //int rowSize = row.Length;
        //int columnSize = row[0].Split('\t').Length;

        //for (int i = 0; i < rowSize; i++)
        //{
        //    string[] column = row[i].Split('\t');
            
        //}
        redHood.level = 1;
        redHood.attackPower = 1;
        redHood.attackSpeed = 1;
        redHood.health = 1;
        redHood.moveSpeed = 1;

        return redHood;
    }

    public override void DebugSO()
    {
        Debug.Log(redHood.level);
    }
}
