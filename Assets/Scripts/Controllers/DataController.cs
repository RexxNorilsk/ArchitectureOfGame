using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController
{
    private List<Record> _data;
    /// <summary>
    /// Constructor
    /// <param string="path">Path to Data</param>
    /// </summary>
    public DataController(string path)
    {
        _data = new List<Record>();
        Init(path);
    }

    /// <summary>
    /// LoadResources
    /// <param ProgramOptions="programOptions">Correct Program options</param>
    /// </summary>
    private void Init(string path) {
        try
        {
            _data = Resources.LoadAll<Record>(path).ToList();
        }
        catch (Exception ex)
        {
            Debug.Log($"[DataManager]Error: {ex.Message}");
        }
        finally
        {
            Debug.Log("[DataManager]Data success load");
        }
    }

    /// <summary>
    /// Get resource from Data Base by name and Type
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    /// <param name="name">Name</param>
    /// <returns>Find record object</returns>
    public T GetResource<T>(string name) where T : Record
    {
        return _data.Find(t=>t.Name == name && t is T) as T;
    }
    /// <summary>
    /// Get ALL resource from Data Base by name and Type
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    /// <param name="name">Name</param>
    /// <returns>Find ALL record objects</returns>
    public List<Record> GetAllResources()
    {
        return _data.FindAll(t => t is Record);
    }

}