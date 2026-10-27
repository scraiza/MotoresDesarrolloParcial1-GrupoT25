using UnityEngine;

public class Health_script : MonoBehaviour
{
    public float health;
    public Game_Manager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<Game_Manager>();
        gameManager.UpdateHealth(gameObject, health);
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
