using UnityEngine;
using UnityEngine.Audio;

public class Health_script : MonoBehaviour
{
    public Game_Manager gameManager;
    public Upgrade_Manager UpgradeManager;
    public float health;
    public GameObject GameOverScreen;
    public AudioSource GameOver_sfx;
    void Start()
    {
        GameOverScreen.SetActive(false);
        UpgradeManager = FindObjectOfType<Upgrade_Manager>();
        health = UpgradeManager.health;
        gameManager = FindObjectOfType<Game_Manager>();
        gameManager.UpdateHealth(gameObject, health);
    }

    void Update()
    {
        if (health <= 0)
        {
            GameOverScreen.SetActive(true);
            GameOver_sfx.Play();
            Destroy(gameObject);
        }
    }
}
