using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Data
{
    int level;
    float attackPower;
    float attackSpeed;
    int health;
    float moveSpeed;
    float maxMoveSpeed;
    float jumpPower;
    float criticalProbability;
    float criticalDamage;
    float wallSlideSpeed;
    Vector2 wallJumpPower;
}


[CreateAssetMenu(menuName = "Data/RedHoodData")]
public class RedHoodData : GameData<Data>
{
    public Data redHood;

    public override Data SetScriptableObject(string tsv)
    {
        string[] row = tsv.Split('\n');
        int rowSize = row.Length;
        int columnSize = row[0].Split('\t').Length;

        for (int i = 0; i < rowSize; i++)
        {
            string[] column = row[i].Split('\t');
            
        }

        return redHood;
    }
}
