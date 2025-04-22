using UnityEngine;
using UnityEngine.UI;

public class UpgradeInfoPanel : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text descriptionText; // if using

    AudioManager am;


    private void Start()
    {
        am = FindObjectOfType<AudioManager>();
    }
    public void ShowUpgradeInfo(Upgrades upgrade)
    {
        nameText.text = upgrade.name;
        descriptionText.text = upgrade.description;

        gameObject.SetActive(true);
    }

    public void HidePanel()
    {
        am.Play("Menu Click");

        gameObject.SetActive(false);
    }
}