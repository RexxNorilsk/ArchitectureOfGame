using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Record", menuName = "Records/Record", order = 1)]
public class Record : ScriptableObject
{
    [SerializeField]
    private string _name;

    public string Name { get => _name; }

    private void OnValidate()
    {
        _name = $"{this.GetType().Name}_{name}";
    }
}
