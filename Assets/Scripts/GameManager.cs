using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [Header("Money Stuff")]
    public float money = 0;
    public Text moneyText;

    public float moneyMultiplier = 1f;
    public float moneyPerSecond = 0.1f;

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
    }

    void Update() {
        money += moneyPerSecond * Time.deltaTime;

        moneyText.text = "Money: $" + money.ToString("0");

        if(currentWaste < maxWaste)
        {
            Timer();
        }
        LoseCondition();
    }

    // Stuff happens when food clicker button is pressed
    public void FoodClickerButtonStuff()
    {
        money += moneyMultiplier;
        moneyText.text = "Money: $" + money.ToString("");
    }

    void Timer()
    {
        if(remainingTime > 0)
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

        print(":)");
    }

    void WinCondition()
    {
        // YOU WIN WOOOOO
    }
    
    void LoseCondition()
    {
        if(currentWaste == maxWaste)
        {
            print("LOSER");
        }
    }
}