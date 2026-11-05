using UnityEngine;

public class Powerup_Script : MonoBehaviour
{
    public float healing = 10f;
    public Game_Manager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<Game_Manager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Health_script health = other.GetComponentInParent<Health_script>();

        if (health != null)
        {
            health.health += healing;
            health.gameManager.UpdateHealth(health.gameObject, health.health);
            Destroy(gameObject);
        }
    }
}
