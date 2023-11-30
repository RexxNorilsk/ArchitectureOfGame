using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "GameOptions", menuName = "Gameplay/New game options")]
public class GameOptions : ScriptableObject
{
    [SerializeField] private string nameOptions = "DefaultName";
    [SerializeField] private float scoreMultiplier = 1f;
    [SerializeField] private float damageMultiplier = 1f;
    [SerializeField] private float creditsMultiplier = 1f;
    [SerializeField] private float timeMultiplier = 1f;
    [SerializeField] private float enemyMultiplier = 1f;
    [SerializeField] private int tricksLevel = 1;
    [SerializeField] private int healthCount = 8;

    public string nameOpt => nameOptions;
    public float score => scoreMultiplier;
    public float damage => damageMultiplier;
    public float credits => creditsMultiplier;
    public float time => timeMultiplier;
    public float enemy => enemyMultiplier;
    public int tricks => tricksLevel;
    public int health => healthCount;

}

