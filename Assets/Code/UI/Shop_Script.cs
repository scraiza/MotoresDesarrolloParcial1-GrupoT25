using UnityEngine;
using TMPro;

public class Shop_Script : MonoBehaviour
{
    public TextMeshProUGUI CurrentCoins;
    public TextMeshProUGUI HealthCost;
    public TextMeshProUGUI SpeedCost;
    public TextMeshProUGUI ScoreMultiplierCost;
    public TextMeshProUGUI HealthPowerupStatus;
    public Upgrade_Manager upgradeManager;
    public void UpdateShop()
    {
        // La tienda esta en el script de los botones, esto se encarga de actualizar los textos de la tienda con los valores actuales del Upgrade_Manager
        upgradeManager = FindObjectOfType<Upgrade_Manager>();
        CurrentCoins.text = $"Current Coins: {upgradeManager.coins}";
        if (upgradeManager.healthUpgradeLevel >= 3)
        {
            HealthCost.text = "Health Upgrade Cost: MAX LEVEL";
        }
        else
        {
            HealthCost.text = $"Health Upgrade Cost: {upgradeManager.healthUpgradeCost}";
        }
        if (upgradeManager.speedUpgradeLevel >= 3)
        {
            SpeedCost.text = "Speed Upgrade Cost: MAX LEVEL";
        }
        else
        {
            SpeedCost.text = $"Speed Upgrade Cost: {upgradeManager.speedUpgradeCost}";
        }
        if (upgradeManager.scoreMultiplierUpgradeLevel >= 3)
        {
            ScoreMultiplierCost.text = "Score Multiplier Cost: MAX LEVEL";
        }
        else
        {
            ScoreMultiplierCost.text = $"Score Multiplier Cost: {upgradeManager.scoreMultiplierUpgradeCost}";
        }
        if (upgradeManager.HealthPowerupUnlocked == true)
        {
            HealthPowerupStatus.text = "Health Powerup: UNLOCKED";
        }
        else
        {
            HealthPowerupStatus.text = "Health Powerup: 5 Coins";
        }
    }
}
