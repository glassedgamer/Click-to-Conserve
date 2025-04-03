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
    
    void Start() {
        moneyText.text = "Money: $" + money.ToString();
    }

    void Update() {
        money += moneyPerSecond * Time.deltaTime;

        moneyText.text = "Money: $" + money.ToString("0");
    }

    // Stuff happens when food clicker button is pressed
    public void FoodClickerButtonStuff()
    {
        money += moneyMultiplier;
        moneyText.text = "Money: $" + money.ToString("");
    }
}