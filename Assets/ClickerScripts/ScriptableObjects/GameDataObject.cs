using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="GameData", menuName="ScriptableObjects/GameDataObject", order=1)]
public class GameDataObject : ScriptableObject
{

    [Header("Upgrade params")]
    public int upgradeParam1 = 3;
    public int upgradeParam2 = 3;

    [Header("Score increase param")]
    [Range(1.2f, 5)]
    public float scoreIncreaseParam = 2.2f;

    [Header("Autoclicker params")]
    public float autoclickerInterval = 1f;
    public int autoclickerParam1 = 3;
    public int autoclickerParam2 = 3;

    public int autoclickerupgradeParam1 = 3;
    public int autoclickerupgradeParam2 = 3;

    public int GetUpgradePrice(int clickerLevel)
    {
        return (int)(upgradeParam1 * Mathf.Pow(clickerLevel + 1, upgradeParam2));
    }

    public int GetAutoClickerBuyPrice(int autoclickerCount)
    {
        return (int)(autoclickerParam1 * Mathf.Pow(autoclickerCount + 1, autoclickerParam2));
    }

    public int GetAutoClickerUpgradePrice(int autoclickerLevel)
    {
        return (int)(autoclickerupgradeParam1 * Mathf.Pow(autoclickerLevel + 1, autoclickerupgradeParam2));
    }
}
