using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshPro))]
public class TextTranslator : MonoBehaviour
{
    public string key;
    public void SetText(LanguageController languageController) {
        GetComponent<Text>().text = languageController.RequestKey(key);
    }
}
