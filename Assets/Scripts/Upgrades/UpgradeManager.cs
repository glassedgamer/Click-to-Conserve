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
    public int clickPower = 1;

    [SerializeField] GameManager gameManager;

    void Start() {
        // Sets the info of each upgrade button to the data from each scriptable object
        for(int i = 0; i < upgradeButtons.Count; i++) {
            upgradeButtons[i].GetComponent<UpgradeButton>().upgradeInfo = availableUpgrades[i];
            upgradeButtons[i].GetComponent<UpgradeButton>().InitializeInfo();
        }
    }

    void Update() {
        // Sets the info of each upgrade button to the data from each scriptable object
        for(int i = 0; i < upgradeButtons.Count; i++) {
            upgradeButtons[i].GetComponent<UpgradeButton>().upgradeInfo = availableUpgrades[i];
            upgradeButtons[i].GetComponent<UpgradeButton>().InitializeInfo();
        }
    }
}
