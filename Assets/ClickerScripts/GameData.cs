using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    [Header("Upgrade params")]
    public int upgradeParam1;
    public int upgradeParam2;

    [Header("Score increase param")]
    [Range(1.2f, 5)]
    public float scoreIncreaseParam;

    [Header("Autoclicker params")]
    public float autoclickerInterval = 1f;
    public int autoclickerParam1;
    public int autoclickerParam2;
}
