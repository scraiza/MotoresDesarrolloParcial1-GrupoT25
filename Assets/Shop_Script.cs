using UnityEngine;
using TMPro;

public class Shop_Script : MonoBehaviour
{
    public TextMeshProUGUI CurrentCoins;
    public TextMeshProUGUI HealthCost;
    public TextMeshProUGUI SpeedCost;
    public Upgrade_Manager upgradeManager;
    public void UpdateShop()
    {
        // La tienda esta en el script de los botones, esto se encarga de actualizar los textos de la tienda con los valores actuales del Upgrade_Manager
        upgradeManager = FindObjectOfType<Upgrade_Manager>();
        CurrentCoins.text = $"Current Coins: {upgradeManager.coins}";
        HealthCost.text = $"Health Upgrade Cost: {upgradeManager.healthUpgradeCost}";
        SpeedCost.text = $"Speed Upgrade Cost: {upgradeManager.speedUpgradeCost}";
    }
}
