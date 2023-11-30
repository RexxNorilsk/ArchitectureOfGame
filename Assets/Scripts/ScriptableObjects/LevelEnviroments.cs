using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelEnviroments", menuName = "Records/LevelEnviroments", order = 1)]
public class LevelEnviroments : Record
{
    public string PlayerPrefab;
    public string PlatformPrefab;
    public string HpBarPrefab;
    public string[] AlongPathPrefabs;
    public bool DrawPathLine;
}
