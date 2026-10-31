using UnityEngine;
using TMPro;

public class Shop_Script : MonoBehaviour
{
    public TextMeshProUGUI CurrentCoins;
    public TextMeshProUGUI HealthCost;
    public Upgrade_Manager upgradeManager;
    public void UpdateShop()
    {
        upgradeManager = FindObjectOfType<Upgrade_Manager>();
        CurrentCoins.text = $"Current Coins: {upgradeManager.coins}";
        HealthCost.text = $"Health Upgrade Cost: {upgradeManager.healthUpgradeCost}";
    }
}
