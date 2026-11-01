using UnityEngine;
using TMPro;
public class Game_Manager : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;
    public Upgrade_Manager upgradeManager;
    public int CoinProgress;
    public int score;
    //Game_Manager maneja la ui del juego, mostrandole al jugador su vida y su puntaje actuales.
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
        score += upgradeManager.scoreMultiplier;
        scoreText.text = $"Score: {score}";
        CoinProgress += upgradeManager.scoreMultiplier;
        if (CoinProgress >= 10)
        {
            upgradeManager.GetMoney();
            CoinProgress = 0;
            // Antes el jugador ganaba siempre una moneda siempre que tenga mas de 10 puntos
            // Ahora el jugador gana una moneda cada 10 puntos, como se intencionaba
        }
    }
}