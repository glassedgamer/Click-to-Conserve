using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] Text nameText;
    //[SerializeField] Text descriptionText;
    [SerializeField] Text costText;
    [SerializeField] Text multiplierText;

    [Header("Upgrade Info")]
    public Upgrades upgradeInfo;
    [SerializeField] UpgradeManager upgradeManager;
    [SerializeField] GameManager gameManager;

    void Start() {
        //InitalizeInfo();
    }

    public void InitializeInfo() {
        nameText.text = upgradeInfo.name.ToString();
        //descriptionText.text = upgradeInfo.description.ToString();
        costText.text = "Cost: $" + upgradeInfo.cost.ToString();
        multiplierText.text = "Click Multiplier: x" + upgradeInfo.clickMultiplier.ToString();
    }

    public void PurchaseUpgrade() {
        if(gameManager.money >= upgradeInfo.cost) {
            // Deduct cost from total money
            gameManager.money -= upgradeInfo.cost;
            gameManager.moneyText.text = "Money: $" + gameManager.money.ToString();

            //clickPower *= upgradeInfo.clickMultiplier;
            upgradeManager.availableUpgrades.Remove(upgradeInfo);
        }
    }
}
