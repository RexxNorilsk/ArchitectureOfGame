using System;
using System.Collections.Generic;


public class SceneLoadInformation
{
    public string SceneName;
    public Action OnLoadScene;
    public Dictionary<string, bool> Data = new Dictionary<string, bool>();

    public SceneLoadInformation(string sceneName, Action onLoadScene)
    {
        SceneName = sceneName;
        OnLoadScene = onLoadScene;
    }
}
