using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [Header("Money Stuff")]
    [SerializeField] int money = 0;
    [SerializeField] Text moneyText;
    
    void Start() {
        moneyText.text = "Money: $" + money.ToString();
    }

    void Update() {
        
    }

    // Stuff happens when food clicker button is pressed
    public void FoodClickerButtonStuff()
    {
        money++;
        moneyText.text = "Money: $" + money.ToString();
    }
}
