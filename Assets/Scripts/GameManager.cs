using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [Header("Money Stuff")]
    public float money = 0;
    public Text moneyText;

    public float moneyMultiplier = 1f;
    public float moneyPerSecond = 0.1f;
    public float loseMoneyVal;
    
    [Header("Game Completion Stuff")]
    public float moneyWinCondition;
    public float moneyLoseCondition;

    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject loseScreen;

    [Header("Time Stuff")]
    [SerializeField] float startingTime;
    float remainingTime;
    [SerializeField] Text timerText;

    [Header("Waste Bin stuff")]
    [SerializeField] float maxWaste;
    float currentWaste = 0;
    [SerializeField] Slider wasteSlider;
    
    void Start() {
        remainingTime = startingTime;

        wasteSlider.maxValue = maxWaste;

        moneyText.text = "Money: $" + money.ToString();

        winScreen.SetActive(false);
        loseScreen.SetActive(false);
    }

    void Update() {
        money += moneyPerSecond * Time.deltaTime;

        moneyText.text = "Money: $" + money.ToString("0");

        // Relation between current value and max value
        if(currentWaste < maxWaste)
        {
            Timer();
        }
        if(currentWaste == maxWaste) {
            // Reseting waste once it reaches max val
            currentWaste = 0;
            wasteSlider.value = currentWaste;

            money -= loseMoneyVal;
            moneyText.text = "Money: $" + money.ToString();
        }

        WinCondition();
        LoseCondition();
    }

    // Stuff happens when food clicker button is pressed
    public void FoodClickerButtonStuff()
    {
        money += moneyMultiplier;
        moneyText.text = "Money: $" + money.ToString("");
    }

    // Counts down and when reaches 0, throw out food and reset timer
    void Timer()
    {
        if(remainingTime > 0 && money < moneyWinCondition && money > moneyLoseCondition)
        {
            remainingTime -= Time.deltaTime;
        } else if (remainingTime < 0)
        {
            remainingTime = startingTime;
            ThrowOutFood();
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void ThrowOutFood()
    {
        //Do the thing
        currentWaste++;
        wasteSlider.value = currentWaste;
    }

    void WinCondition()
    {
        // YOU WIN WOOOOO
        if(money >= moneyWinCondition) {
            winScreen.SetActive(true);
            RestartGame();
        }
    }
    
    void LoseCondition()
    {
        if(money <= moneyLoseCondition) {
            loseScreen.SetActive(true);
            RestartGame();
        }
    }

    void RestartGame() {
        if(Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene("MainGame");
        }
    }
}