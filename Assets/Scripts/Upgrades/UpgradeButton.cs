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
    [SerializeField] Text clickMultiplierText;
    [SerializeField] Text timeMultiplierText;
    [SerializeField] RawImage BG;

    [Header("Upgrade Info")]
    public Upgrades upgradeInfo;
    [SerializeField] UpgradeManager upgradeManager;
    [SerializeField] GameManager gameManager;

    [Header("Random Stuff")]
    [SerializeField] Color cantPurchase;
    [SerializeField] Color purchase;

    void Start() {
        //InitalizeInfo();
    }

    void Update()
    {
        if (gameManager.money <= upgradeInfo.cost - 0.5f)
        {
            BG.color = cantPurchase;
        } else if (gameManager.money >= upgradeInfo.cost - 0.5f)
        {
            BG.color = purchase;
        }
    }

    public void InitializeInfo() {
        nameText.text = upgradeInfo.name.ToString();
        //descriptionText.text = upgradeInfo.description.ToString();
        costText.text = "Cost: $" + upgradeInfo.cost.ToString();
        clickMultiplierText.text = "Click Multiplier: x" + upgradeInfo.clickMultiplier.ToString();
        timeMultiplierText.text = "Time Multiplier: x" + upgradeInfo.timeMultiplier.ToString();
    }

    public void PurchaseUpgrade() {
        if(gameManager.money >= upgradeInfo.cost) {
            // Deduct cost from total money
            gameManager.money -= upgradeInfo.cost;
            gameManager.moneyText.text = "Money: $" + gameManager.money.ToString();

            gameManager.moneyMultiplier *= upgradeInfo.clickMultiplier;
            gameManager.moneyPerSecond = (gameManager.moneyPerSecond + 0.5f) * upgradeInfo.timeMultiplier;

            upgradeManager.availableUpgrades.Remove(upgradeInfo);
            InitializeInfo();
        }
    }
}
