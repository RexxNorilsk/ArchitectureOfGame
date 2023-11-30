using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "ProgramOptions", menuName = "ProgramOptions")]
public class ProgramOptions : ScriptableObject
{
    [SerializeField]
    private string _language;
    [SerializeField]
    private string _pathToSave;
    [SerializeField]
    private string[] _pathsToAssetBundles;
    [SerializeField]
    private string _defaultDiffculty;
    [SerializeField]
    private string _gameSceneName;
    [SerializeField]
    private string _dataBaseFolder;
    [SerializeField]
    private ObjectsToSpawnInScene[] _objectsToSpawnInScenes;
    [SerializeField]
    private LevelEnviroments _defaultLevelEnviroments;

    private static ProgramOptions _correct;
    

    public string PathToSave { 
        get => _pathToSave.Replace("%streamingAssetsPath%", Application.streamingAssetsPath); 
        set => _pathToSave = value; 
    }
    public string Language { get => _language; set => _language = value; }
    public string[] PathsToAssetBundles { get => _pathsToAssetBundles; set => _pathsToAssetBundles = value; }
    public string DefaultDiffculty { get => _defaultDiffculty; set => _defaultDiffculty = value; }
    public string GameSceneName { get => _gameSceneName; set => _gameSceneName = value; }
    public string DataBaseFolder { get => _dataBaseFolder; set => _dataBaseFolder = value; }
    public ObjectsToSpawnInScene[] ObjectsToSpawnInScenes { get => _objectsToSpawnInScenes; set => _objectsToSpawnInScenes = value; }
    public LevelEnviroments DefaultLevelEnviroments { get => _defaultLevelEnviroments; set => _defaultLevelEnviroments = value; }

    public static ProgramOptions GetCorrect()
    {
        if(_correct == null)
            _correct = Resources.LoadAll<ProgramOptions>("/")[0];
        return _correct;
    }

    [System.Serializable]
    public class ObjectsToSpawnInScene {
        public string SceneName;
        public ObjectsToSpawn ObjectsToSpawn; 
    }

    
}
