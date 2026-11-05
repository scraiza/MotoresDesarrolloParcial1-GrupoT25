using UnityEngine;

public class Achivement_Manager : MonoBehaviour
{
    public Upgrade_Manager upgradeManager;
    public int UpgradesUnlocked = 0;
    public int AchivementsUnlocked = 0;
    public int TotalCoinsCollected = 0;
    public GameObject AchivementBlocker1;
    public GameObject AchivementBlocker2;
    public GameObject AchivementBlocker3;
    public GameObject AchivementBlocker4;
    public void AchivementMenu()
    {
        AchivementsUnlocked = 0;
        upgradeManager = FindObjectOfType<Upgrade_Manager>();
        if (upgradeManager.UpgradesUnlocked == 10)
        {
            AchivementBlocker1.SetActive(false);
            AchivementsUnlocked++;
        }
        if (upgradeManager.totalCoinsCollected >= 20)
        {
            AchivementBlocker3.SetActive(false);
            AchivementsUnlocked++;
        }
        if (upgradeManager.bestTime >= 40f)
        {
            AchivementBlocker4.SetActive(false);
            AchivementsUnlocked++;
        }
        if (AchivementsUnlocked == 3)
        {
            AchivementBlocker2.SetActive(false);
        }
    }
}
