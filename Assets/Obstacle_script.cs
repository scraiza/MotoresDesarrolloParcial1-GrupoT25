using UnityEngine;

public class Obstacle_script : MonoBehaviour
{
    public float damage = 10f;
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
            health.health -= damage;
            health.gameManager.UpdateHealth(health.gameObject, health.health);
            Destroy(gameObject);
            gameManager.UpdateScore();
        }
    }
}