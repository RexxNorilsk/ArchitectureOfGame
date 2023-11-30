using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using System.IO;
using UnityEngine.Events;

public class LanguageController
{
    private Dictionary<string, string> _data;

    public  UnityEvent OnInit = new UnityEvent();
    private bool _isInit = false;
    private string _languageFile;

    public string LanguageFile { get => _languageFile; set => _languageFile = value; }

    /// <summary>
    /// Init localization
    /// </summary>
    public LanguageController(string selectLanguage)
    {
        Init(selectLanguage);
    }


    /// <summary>
    /// Load localization
    /// </summary>
    public void Init(string selectLanguage)
    {
        LanguageFile = selectLanguage;
        _data = new Dictionary<string, string>();
        LanguageData languageData = Deserialize<LanguageData>(Path.Combine(Application.streamingAssetsPath, "Translate", selectLanguage + ".xml"));
        foreach (LanguageDot dot in languageData.dots)
        {
            _data[dot.key] = dot.data;
        }
        _isInit = true;
        OnInit.Invoke();
    }

    /// <summary>
    /// Get status LanguageController
    /// </summary>
    /// <returns>status</returns>
    public bool IsInit()
    {
        return _isInit;
    }

    /// <summary>
    /// Deserialize data to dictionary from xml file
    /// </summary>
    /// <param name="path">Path to file</param>
    private T Deserialize<T>(string path)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        StreamReader reader = new StreamReader(path);
        T deserialized = (T)serializer.Deserialize(reader.BaseStream);
        reader.Close();
        return deserialized;
    }

    /// <summary>
    /// Get localized text by key
    /// </summary>
    /// <param name="key">key localization</param>
    /// <returns>localizated text</returns>
    public string RequestKey(string key) {
        string result;
        if (_data.TryGetValue(key, out result)) return result.Replace('[', '<').Replace(']', '>');
        return "Error";
    }

    /// <summary>
    /// Get localized text combined by keys
    /// </summary>
    /// <param name="keys">keys localization</param>
    /// <param name="separator">separator between texts</param>
    /// <returns>combined localizated texts</returns>
    public string MultileRequested(string[] keys, string separator = "")
    {
        string result = RequestKey(keys[0]);
        for (int i = 1; i < keys.Length; i++)
        {
            result += separator+RequestKey(keys[i]);
        }
        return result;
    }

    /// <summary>
    /// Get all languages
    /// </summary>
    /// <returns>All languages in Translate folder</returns>
    public Languages GetAllLanguages()
    {
        return 
            Deserialize<Languages>(Path.Combine(Application.streamingAssetsPath, "Translate", "Localizations.xml"));
    }

}
[XmlRoot("lang")]
public class LanguageData
{
    [XmlElement("name")]
    public string name;
    [XmlArray("dots"), XmlArrayItem("dot")]
    public List<LanguageDot>dots;
}
public class LanguageDot
{
    [XmlAttribute("key")]
    public string key;
    [XmlAttribute("data")]
    public string data;
}

[XmlRoot("languages")]
public class Languages
{
    [XmlArray("list"), XmlArrayItem("language")]
    public List<Language> list;
}
public class Language
{
    [XmlAttribute("name")]
    public string name;
    [XmlAttribute("file")]
    public string fileName;
}