using UnityEngine;
using TMPro;

public class Game_Manager : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;
    private int score = 0;

    private void Start()
    {
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
    }
}
