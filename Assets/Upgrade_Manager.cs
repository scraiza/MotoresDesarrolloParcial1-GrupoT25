using UnityEngine;
public class Upgrade_Manager : MonoBehaviour
{
    private static Upgrade_Manager instance;

    public Game_Manager gameManager;
    public int coins = 0;
    public int health = 100;
    public int healthUpgradeCost = 1;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void GetMoney()
    {
        coins ++;
        print("You have " + coins + " coins.");
    }
}