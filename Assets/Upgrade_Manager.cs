using UnityEngine;
public class Upgrade_Manager : MonoBehaviour
{
    private static Upgrade_Manager instance;

    public Game_Manager gameManager;
    public int coins = 0;
    public int totalCoinsCollected = 0;
    public int health = 100;
    public int healthUpgradeCost = 1;
    public int speedUpgradeCost = 1;
    public float speed = 10f;
    public int scoreMultiplier = 1;
    public int scoreMultiplierUpgradeCost = 3;
    public int healthUpgradeLevel = 0;
    public int speedUpgradeLevel = 0;
    public int scoreMultiplierUpgradeLevel = 0;
    public int UpgradesUnlocked = 0;
    public float bestTime = 0f;
    //Upgrade_Manager es un singleton, de aca agarran los valores de las mejoras y el costo de las mismas
    //Tambien cuenta la cantidad de monedas que tiene el jugador.
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        Achivement_Manager achivementManager = FindObjectOfType<Achivement_Manager>();
    }

    public void GetMoney()
    {
        coins ++;
        print("You have " + coins + " coins.");
        totalCoinsCollected++;
    }
}