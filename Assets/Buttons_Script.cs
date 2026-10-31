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
