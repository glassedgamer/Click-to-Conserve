using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Upgrades : ScriptableObject
{
    [Header("Info Stuff")]
    public new string name;
    public string description;
    public int cost;

    [Header("Multipliers")]
    public int timeMultiplier;
    public int clickMultiplier;
}
