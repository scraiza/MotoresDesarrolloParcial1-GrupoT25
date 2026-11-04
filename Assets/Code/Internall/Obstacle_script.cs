using UnityEngine;
using UnityEngine.Audio;
public class Obstacle_script : MonoBehaviour
{
    public float damage = 10f;
    public Game_Manager gameManager;
    public GameObject particles;
    public AudioSource destruction_sfx;
    void Start()
    {
        gameManager = FindObjectOfType<Game_Manager>();
        destruction_sfx = GameObject.Find("Destruction_sfx").GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Health_script health = other.GetComponentInParent<Health_script>();

        if (health != null)
        {
            health.health -= damage;
            health.gameManager.UpdateHealth(health.gameObject, health.health);
            Instantiate(particles, transform.position, Quaternion.identity);
            destruction_sfx.Play();
            Destroy(gameObject);
            gameManager.UpdateScore();
        }
    }
}