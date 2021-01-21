using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HealthData : ScriptableObject
{
    public int healthValue;

    public void OnEnable()
    {
        healthValue = 100;
    }
}
