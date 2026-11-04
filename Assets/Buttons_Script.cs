using UnityEngine;
using UnityEngine.Audio;
public class Buttons_Script : MonoBehaviour
{
    public GameObject ImageBlocker;
    public GameObject ImageBlocker2;
    public Upgrade_Manager UpgradeManager;
    public Shop_Script ShopScript;
    public AudioSource upgrade_sfx;
    
    private void Awake()
    {
        if (ImageBlocker != null)
        {
            ImageBlocker.SetActive(false);
        }
        if (ImageBlocker2 != null)
        {
            ImageBlocker2.SetActive(false);
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
    //Upgrade menu starts here
    public void UpgradeHealth()
    {
        if (UpgradeManager.healthUpgradeLevel >= 3)
        {
            print("Health is already at max level.");
            return;
        }
        else
        {
            if (UpgradeManager.coins >= UpgradeManager.healthUpgradeCost)
            {
                UpgradeManager.coins -= UpgradeManager.healthUpgradeCost;
                UpgradeManager.health += 10;
                UpgradeManager.healthUpgradeCost += 1;
                UpgradeManager.healthUpgradeLevel++;
                UpgradeManager.UpgradesUnlocked++;
                ShopScript.UpdateShop();
                upgrade_sfx.Play();
                print("Health upgraded! Current health: " + UpgradeManager.health);
            }
        }
    }
    public void UpgradeSpeed()
    {
        if (UpgradeManager.speedUpgradeLevel >= 3)
        {
            print("Speed is already at max level.");
            return;
        }
        else
        {
            if (UpgradeManager.coins >= UpgradeManager.speedUpgradeCost)
            {
                UpgradeManager.coins -= UpgradeManager.speedUpgradeCost;
                UpgradeManager.lateralSpeed += 5f;
                UpgradeManager.speedUpgradeCost += 1;
                UpgradeManager.speedUpgradeLevel++;
                UpgradeManager.UpgradesUnlocked++;
                ShopScript.UpdateShop();
                upgrade_sfx.Play();
                print("Speed upgraded! Current lateral speed: " + UpgradeManager.lateralSpeed);
            }
        }
    }
    public void UpgradeScoreMultiplier()
    {
        if (UpgradeManager.scoreMultiplierUpgradeLevel >= 3)
        {
            print("Score multiplier is already at max level.");
            return;
        }
        else
        {
            if (UpgradeManager.coins >= UpgradeManager.scoreMultiplierUpgradeCost)
            {
                UpgradeManager.coins -= UpgradeManager.scoreMultiplierUpgradeCost;
                UpgradeManager.scoreMultiplier += 1;
                UpgradeManager.scoreMultiplierUpgradeLevel++;
                UpgradeManager.scoreMultiplierUpgradeCost += 3;
                UpgradeManager.UpgradesUnlocked++;
                ShopScript.UpdateShop();
                upgrade_sfx.Play();
                print("Score multiplier upgraded! Current score multiplier: " + UpgradeManager.scoreMultiplier);
            }
        }
    }
    //Upgrade menu ends here
    public void CloseUpgradeMenu()
    {
        ImageBlocker.SetActive(false);
    }
    public void OpenAchivementMenu()
    {
        ImageBlocker2.SetActive(true);
        Achivement_Manager achivementManager = FindObjectOfType<Achivement_Manager>();
        achivementManager.AchivementMenu();
    }
    public void CloseAchivementMenu()
    {
        ImageBlocker2.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
