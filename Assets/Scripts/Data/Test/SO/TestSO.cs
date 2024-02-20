using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats
{
    public string name;
    public int birthday;
    public string sex;
}


[CreateAssetMenu(fileName = "TestSo", menuName = "scriptableObject/TestSo")]
[System.Serializable]
public class TestSO : ScriptableObject
{
    public float version;
    public Stats[] statsArray;
}