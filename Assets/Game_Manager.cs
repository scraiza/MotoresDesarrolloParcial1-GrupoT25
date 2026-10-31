using UnityEngine;
using TMPro;
public class Game_Manager : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;
    public Upgrade_Manager upgradeManager;
    public int score;
    private void Start()
    {
        upgradeManager = FindObjectOfType<Upgrade_Manager>();
        score = 0;
        scoreText.text = $"Score: {score}";
    }
    public void UpdateHealth(GameObject player, float health)
    {
        healthText.text = $"Health: {health:0.##}";
    }
    public void UpdateScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
        if (score >= 10)
        {
            upgradeManager.GetMoney();
        }
    }
}