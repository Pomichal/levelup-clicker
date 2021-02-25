using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Game data")]
    public int score;
    [SerializeField]
    private int scoreIncrease;
    public int clickerLevel;

    [Space(15)]
    [Tooltip("Game Data file with actual game settings")]
    public GameData gameData;

    [Header("Autoclicker data")]
    public int autoclickerLevel;
    public int autoclickerCount;
    public int AutoclickerIncrease;

    [Header("UI elements")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI autoClickerCountText;
    public Button upgradeClickerButton;
    public Button buyAutoclickerButton;
    public Slider upgradeSlider;
    public Slider buyAutoclickerSlider;

    public float timer;

    void Start()
    {
        score = 0;
        scoreIncrease = 1;
        clickerLevel = 0;
        autoclickerLevel = 0;
        AutoclickerIncrease = 1;
        OnScoreUpdate();
        ChangeAutoClickerCountText();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= gameData.autoclickerInterval)
        {
            CollectAutoclickerScore();
            timer = 0;
        }
    }

    public void CollectSCore()
    {
        score += scoreIncrease;
        OnScoreUpdate();
    }

    public void CollectAutoclickerScore()
    {
        score += autoclickerCount * AutoclickerIncrease;
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

    public void UpgradeAutoclicker()
    {
        int cost = GetAutoClickerUpgradePrice();
        if(score >= cost)
        {
            autoclickerCount++;
            ChangeAutoClickerCountText();
            score -= cost;
            OnScoreUpdate();
        }
        else
        {
            Debug.Log("not enough coins for autoclicker (" + cost + ")");
        }
    }

    public int GetUpgradePrice()
    {
        return (int)(gameData.upgradeParam1 * Mathf.Pow(clickerLevel + 1, gameData.upgradeParam2));
    }

    public int GetAutoClickerUpgradePrice()
    {
        return (int)(gameData.autoclickerParam1 * Mathf.Pow(autoclickerCount + 1, gameData.autoclickerParam2));
    }

    public void ChangeUpgradeSlider(int coins, float maxValue)
    {
        //upgradeSlider.value = coins / maxValue;

        upgradeSlider.maxValue = maxValue;
        upgradeSlider.value = coins;
    }

    public void ChangeAutoclickerCountSlider(int coins, float maxValue)
    {
        buyAutoclickerSlider.value = coins / maxValue;
    }

    public void ChangeAutoClickerCountText()
    {
        autoClickerCountText.text = "Autoclickers: " + autoclickerCount;
    }

    public void OnScoreUpdate()
    {
        scoreText.text = "Score: <size=10>" + score;
        int upgradeCost = GetUpgradePrice();
        int autoclickerCost = GetAutoClickerUpgradePrice();

        upgradeClickerButton.interactable = score >= upgradeCost;
        buyAutoclickerButton.interactable = score >= autoclickerCost;


        ChangeUpgradeSlider(score, upgradeCost);
        ChangeAutoclickerCountSlider(score, autoclickerCost);
    }
}
