using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    /*
        FOR LATER: Seperate available upgrades into three sepearte lists
        so it's easier to keep each set of upgrades in one spot
    */

    public List<Upgrades> availableUpgrades;
    public List<Button> upgradeButtons;

    [SerializeField] GameManager gameManager;

    [Header("Food Items")]
    public GameObject clickMe;
    public GameObject chicken;
    public GameObject carrots;
    public GameObject can;

    void Start() {
        SetPurchaseButtons();

        clickMe.SetActive(true);
        chicken.SetActive(false);
        carrots.SetActive(false);
        can.SetActive(false);
    }

    void Update() {
        SetPurchaseButtons();
    }

    void SetPurchaseButtons() {
        // Sets the info of each upgrade button to the data from each scriptable object
        for (int i = 0; i < upgradeButtons.Count; i++)
        {
            if (i < availableUpgrades.Count)
            {
                upgradeButtons[i].gameObject.SetActive(true);
                upgradeButtons[i].GetComponent<UpgradeButton>().upgradeInfo = availableUpgrades[i];
                upgradeButtons[i].GetComponent<UpgradeButton>().InitializeInfo();
            }
            else
            {
                upgradeButtons[i].gameObject.SetActive(false); // Hide button if no upgrade available
            }
        }
    }
}
