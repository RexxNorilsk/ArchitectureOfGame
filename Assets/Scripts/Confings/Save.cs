using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

[Serializable]
public class Save
{
    public string language { get; set; } = "Rus";
    public int credits { get; set; } = 0;
    public List<int> weapons { get; set; } = new List<int>();

    public List<string> collectables { get; set; } = new List<string>();

    public List<LevelSave> levelSaves;
    public List<int> levelPath;
}
[Serializable]
public class LevelSave
{
    public Vector2 levelPos = new Vector2(0,0);
    public List<int> nexts;
    public int diffculty = 0;
}


