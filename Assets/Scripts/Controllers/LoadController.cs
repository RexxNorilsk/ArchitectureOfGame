using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class LoadController
{
    private Dictionary<string, AssetBundle> _data;

    /// <summary>
    /// LoadManager init
    /// </summary>
    /// <param name="bundles">String paths to bundles</param>
    public LoadController(string[] bundles)
    {
        Init(bundles);
    }

    /// <summary>
    /// Initializing bundles from a files
    /// </summary>
    /// <param name="programOptions">Correct Program options</param>
    private void Init(string[] bundles)
    {
        Debug.Log("[LoadManager]Starting loading");
        _data = new Dictionary<string, AssetBundle>();
        for (int i = 0; i < bundles.Length;)
            _data[bundles[i]] = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, bundles[i++]));
    }

    /// <summary>
    /// GetResource from bundle
    /// </summary>
    /// <param name="name">Name file</param>
    /// <param name="bundleName">Bundle name, default - main</param>
    /// <returns>Find UnityEngine.Object by name</returns>
    public T GetResource<T>(string name, string bundleName = "main") where T : UnityEngine.Object {
            return (Resources.Load<T>(name) == null) ? (null) : (Resources.Load<T>(name));
    }

    /// <summary>
    /// Get list all assets in streaming assets by path and extension
    /// </summary>
    /// <param name="name">Path to folder (Example: Translate)</param>
    /// <param name="extension">Extension find files</param>
    /// <returns>List of names files</returns>
    public List<string> GetStreamingAssetsInFolder(string path, string extension)
    {
        var fullPath = Path.Combine(Application.streamingAssetsPath, path);
        DirectoryInfo dirInfo = new DirectoryInfo(fullPath);
        var data = dirInfo.GetFiles().ToList().FindAll(t => t.Extension.Contains(extension));
        return data.Select(t => t.FullName).ToList();
    }
}