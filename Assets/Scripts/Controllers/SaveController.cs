using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class SaveController
{
    private Save _save;

    private string _saveFile = "";

    private string SaveFile { get => _saveFile; set => _saveFile = value; }
    public Save Save { get => _save; private set => _save = value; }

    /// <summary>
    /// Constructor SaveController
    /// </summary>
    /// <param string="saveFile">Path to save file</param>
    public SaveController(string saveFile)
    {
        Init(saveFile);
    }

    /// <summary>
    /// Add money to save
    /// </summary>
    /// <param name="added">Count money to save</param>
    /// <returns>Success operation</returns>
    public bool AddMoney(int added)
    {
        if (Save.credits + added < 0)
        {
            return false;
        }
        else
        {
            Save.credits += added;
            return true;
        }
    }


    /// <summary>
    /// Set language
    /// </summary>
    /// <param name="language">Correct language</param>
    public void SetLanguage(Language language)
    {
        _save.language = language.name;
    }

    /// <summary>
    /// Initializing saving from a file
    /// <param string="saveFile">Path to save file</param>
    /// </summary>
    public void Init(string saveFile)
    {
        SaveFile = saveFile;
    }

    /// <summary>
    /// Save options changes
    /// </summary>
    public void SaveOptions() {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Save));
        UnityEngine.Debug.Log("[SaveController]Starting saving options...");
        try
        {
            using (FileStream fs = new FileStream(SaveFile, FileMode.Create))
            {
                xmlSerializer.Serialize(fs, Save);
            }
        }
        catch (Exception e)
        {
            UnityEngine.Debug.Log($"[SaveController]{e.Message}");
        }
        finally
        {
            UnityEngine.Debug.Log("[SaveController]Successfully!");
        }
    }
    /// <summary>
    /// Loading save file
    /// </summary>
    public void LoadOptions()
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Save));
        UnityEngine.Debug.Log("[SaveController]Starting loading options...");
        if (File.Exists(SaveFile))
        {
            UnityEngine.Debug.Log("[SaveController]The save file is detected, begin deserialization of the settings");
            try
            {
                using (FileStream fs = new FileStream(SaveFile, FileMode.OpenOrCreate))
                {
                    Save = xmlSerializer.Deserialize(fs) as Save;
                }
            }
            catch (Exception e)
            {
                UnityEngine.Debug.Log($"[SaveController]{e.Message}");
            }
            finally
            {
                UnityEngine.Debug.Log("[SaveController]Successfully!");
            }
        }
        else
        {
            UnityEngine.Debug.Log("[SaveController]No save file detected.");
            SetDefaultOptions();
        }
    }
    /// <summary>
    /// Create save file default
    /// </summary>
    public void SetDefaultOptions()
    {
        
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Save));
        Save = new Save();
        Save.credits = 0;
        Save.weapons.Add(0);

        UnityEngine.Debug.Log("[SaveController]Starting to serialize the default save file...");
        try
        {
            using (FileStream fs = new FileStream(SaveFile, FileMode.Create))
            {
                xmlSerializer.Serialize(fs, Save);
            }
        }
        catch (Exception e)
        {
            UnityEngine.Debug.Log($"[SaveController]{e.Message}");
        }
        finally
        {
            UnityEngine.Debug.Log("[SaveController]Successfully!");
        }
    }
}
