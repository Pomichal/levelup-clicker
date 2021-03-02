using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Game data")]
    public string playerName;
    public int score;
    [SerializeField]
    private int scoreIncrease;
    public int clickerLevel;


    [Header("Autoclicker data")]
    public int autoclickerLevel;
    public int autoclickerCount;
    public int autoclickerIncrease;

    [Header("UI elements")]
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI autoClickerCountText;
    public TextMeshProUGUI autoClickerLevelText;
    public Button upgradeClickerButton;
    public Button buyAutoclickerButton;
    public Slider upgradeSlider;
    public Slider buyAutoclickerSlider;
    public Button UpgradeAutoclickerButton;
    public Slider UpgradeAutoclickerSlider;

    public SettingsPopup settingsPopup;

    public float timer;

    private GameDataObject gameData;
    private bool showSliders;

    void Start()
    {
        gameData = Resources.Load<GameDataObject>("Configs/GameData");
        score = 0;
        scoreIncrease = 1;
        clickerLevel = 0;
        autoclickerLevel = 0;
        autoclickerIncrease = 1;
        playerName = "Player1234";
        OnScoreUpdate();
        ChangeAutoClickerCountText();
        ChangeAutoclickerLevelText();
        ShowPlayerName();
        SetSlidersVisibility(true);

        //GameDataObject[] configs = Resources.LoadAll<GameDataObject>("Configs");

        //foreach(GameDataObject config in configs)
        //{
            //Debug.Log(config.name);
        //}
        //SpawnCubes();
    }

    //void SpawnCubes()
    //{
        //GameObject cubePrefab = Resources.Load<GameObject>("Cube");

        //for(int i=0; i<3; i++)
        //{
            //Instantiate(cubePrefab, new Vector3(i, 0, 0), Quaternion.identity);
        //}
    //}

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
        score += autoclickerCount * autoclickerIncrease;
        OnScoreUpdate();
    }

    public void UpgradeClicker()
    {
        int cost = gameData.GetUpgradePrice(clickerLevel);
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

    public void BuyAutoclicker()
    {
        int cost = gameData.GetAutoClickerUpgradePrice(autoclickerCount);
        if(score >= cost)
        {
            autoclickerCount++;
            ChangeAutoClickerCountText();
            ChangeAutoclickerLevelText();
            score -= cost;
            OnScoreUpdate();
        }
        else
        {
            Debug.Log("not enough coins for autoclicker (" + cost + ")");
        }
    }

    public void UpgradeAutoclicker()
    {
        int cost = gameData.GetAutoClickerUpgradePrice(autoclickerIncrease);
        if(score >= cost)
        {
            autoclickerIncrease = (int)(autoclickerIncrease * gameData.scoreIncreaseParam);
            score -= cost;
            ChangeAutoclickerLevelText();
            OnScoreUpdate();
        }
        else
        {
            Debug.Log("not enough coins for autoclicker (" + cost + ")");
        }

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

    public void ChangeAutoclickerUpgradeSlider(int coins, float maxValue)
    {
        UpgradeAutoclickerSlider.value = coins / maxValue;
    }

    public void ChangeAutoClickerCountText()
    {
        autoClickerCountText.text = "Autoclickers: " + autoclickerCount;
    }

    public void ChangeAutoclickerLevelText()
    {
        autoClickerLevelText.text = "Autoclicker income:\n" + autoclickerCount * autoclickerIncrease + "/" + gameData.autoclickerInterval + " s";
    }

    public void ShowPlayerName()
    {
        playerNameText.text = playerName;
    }

    public void SetName(string newName)
    {
        playerName = newName;
        ShowPlayerName();
    }

    public void SetSlidersVisibility(bool newValue)
    {
        showSliders = newValue;
        upgradeSlider.gameObject.SetActive(showSliders);
        buyAutoclickerSlider.gameObject.SetActive(showSliders);
        UpgradeAutoclickerSlider.gameObject.SetActive(showSliders);
    }

    public void OnScoreUpdate()
    {
        scoreText.text = "Score: <size=10>" + score;
        int upgradeCost = gameData.GetUpgradePrice(clickerLevel);
        int autoclickerCost = gameData.GetAutoClickerUpgradePrice(autoclickerCount);
        int autoclickerUpgradeCost = gameData.GetAutoClickerUpgradePrice(autoclickerIncrease);

        upgradeClickerButton.interactable = score >= upgradeCost;
        buyAutoclickerButton.interactable = score >= autoclickerCost;
        UpgradeAutoclickerButton.interactable = score >= autoclickerUpgradeCost;

        ChangeUpgradeSlider(score, upgradeCost);
        ChangeAutoclickerCountSlider(score, autoclickerCost);
        ChangeAutoclickerUpgradeSlider(score, autoclickerUpgradeCost);
    }

    public void ShowSettings()
    {
        settingsPopup.gameObject.SetActive(true);
    }
}
