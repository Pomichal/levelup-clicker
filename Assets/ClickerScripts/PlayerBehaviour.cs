using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    public int score;
    public int scoreIncrease;
    public int clickerLevel;

    public GameData gameData;

    public TextMeshProUGUI scoreText;
    public Button upgradeClickerButton;

    void Start()
    {
        score = 0;
        scoreIncrease = 1;
        clickerLevel = 0;
        OnScoreUpdate();
    }

    public void CollectSCore()
    {
        score += scoreIncrease;
        OnScoreUpdate();
    }

    public void UpgradeClicker()
    {
        int cost = GetUpgradePrice();
        if(score >= cost)
        {
            scoreIncrease = (int)(scoreIncrease * gameData.scoreIncreaseParam);
            score -= cost;
            clickerLevel++;
            OnScoreUpdate();
        }
        else
        {
            Debug.Log("not enough coins (" + cost + ")");
        }
    }

    public int GetUpgradePrice()
    {
        return (int)(gameData.upgradeParam1 * Mathf.Pow(clickerLevel + 1, gameData.upgradeParam2));
    }

    public void OnScoreUpdate()
    {
        scoreText.text = "Score: " + score;
        int upgradeCost = GetUpgradePrice();

        upgradeClickerButton.interactable = score >= upgradeCost;
    }
}
