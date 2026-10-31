using UnityEngine;

public class Buttons_Script : MonoBehaviour
{
    public GameObject ImageBlocker;
    public Upgrade_Manager UpgradeManager;
    public Shop_Script ShopScript;
    
    private void Awake()
    {
        if (ImageBlocker != null)
        {
            ImageBlocker.SetActive(false);
        }

        UpgradeManager = FindObjectOfType<Upgrade_Manager>();
        ShopScript = FindObjectOfType<Shop_Script>();
    }
    public void GoToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main_Menu");
    }
    public void startGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main_Game");
    }
    public void UpgradeMenu()
    {
        ImageBlocker.SetActive(true);
        ShopScript.UpdateShop();
    }
    public void UpgradeHealth()
    {
        if (UpgradeManager.coins >= UpgradeManager.healthUpgradeCost)
        {
            UpgradeManager.coins -= UpgradeManager.healthUpgradeCost;
            UpgradeManager.health += 10;
            UpgradeManager.healthUpgradeCost += 1;
            ShopScript.UpdateShop();
            print("Health upgraded! Current health: " + UpgradeManager.health);
        }
    }
    public void UpgradeSpeed()
    {
        if (UpgradeManager.coins >= UpgradeManager.speedUpgradeCost)
        {
            UpgradeManager.coins -= UpgradeManager.speedUpgradeCost;
            UpgradeManager.lateralSpeed += 5f;
            UpgradeManager.speedUpgradeCost += 1;
            ShopScript.UpdateShop();
            print("Speed upgraded! Current lateral speed: " + UpgradeManager.lateralSpeed);
        }
    }
    public void CloseUpgradeMenu()
    {
        ImageBlocker.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
