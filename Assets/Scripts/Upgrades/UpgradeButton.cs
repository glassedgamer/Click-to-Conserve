using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    AudioManager am;

    [Header("UI Elements")]
    [SerializeField] Text nameText;
    //[SerializeField] Text descriptionText;
    [SerializeField] Text costText;
    [SerializeField] Text clickMultiplierText;
    [SerializeField] Text timeMultiplierText;
    [SerializeField] RawImage BG;
    [SerializeField] UpgradeInfoPanel infoPanel;

    [Header("Upgrade Data")]
    public Upgrades upgradeInfo;
    [SerializeField] UpgradeManager upgradeManager;
    [SerializeField] GameManager gameManager;

    [Header("Random Stuff")]
    [SerializeField] Color cantPurchase;
    [SerializeField] Color purchase;

    void Start() {
        //InitalizeInfo();
        am = FindObjectOfType<AudioManager>();
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
            am.Play("Buy");

            // Deduct cost from total money
            gameManager.money -= upgradeInfo.cost;
            gameManager.moneyText.text = "Money: $" + gameManager.money.ToString();

            gameManager.moneyMultiplier *= upgradeInfo.clickMultiplier;
            gameManager.moneyPerSecond = (gameManager.moneyPerSecond + 0.5f) * upgradeInfo.timeMultiplier;

            gameManager.startingTime += 2;
            gameManager.loseMoneyVal *= upgradeInfo.timeMultiplier;

            upgradeManager.availableUpgrades.Remove(upgradeInfo);

            ChangeFoodIcon();

            InitializeInfo();
        } else
        {
            am.Play("Can't Click");
        }
    }

    void ChangeFoodIcon()
    {
        if (upgradeInfo.name == "High Perishables")
        {
            upgradeManager.clickMe.SetActive(false);
            upgradeManager.chicken.SetActive(true);
            upgradeManager.carrots.SetActive(false);
            upgradeManager.can.SetActive(false);
        } else if (upgradeInfo.name == "Less Perishable")
        {
            upgradeManager.clickMe.SetActive(false);
            upgradeManager.chicken.SetActive(false);
            upgradeManager.carrots.SetActive(true);
            upgradeManager.can.SetActive(false);
        } else if (upgradeInfo.name == "Non-Perishables")
        {
            upgradeManager.clickMe.SetActive(false);
            upgradeManager.chicken.SetActive(false);
            upgradeManager.carrots.SetActive(false);
            upgradeManager.can.SetActive(true);
        }
    }

    public void ShowInfo()
    {
        am.Play("Menu Click");

        infoPanel.ShowUpgradeInfo(upgradeInfo);
    }

}
