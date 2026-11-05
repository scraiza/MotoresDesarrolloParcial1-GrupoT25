using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class Drone_Script_Test : MonoBehaviour
{
    public Transform Target;
    public NavMeshAgent Agent;
    public float damage = 20f;
    public Game_Manager gameManager;
    public GameObject explosionEffectPrefab;
    public AudioSource explosionSound;
    void Start()
    {
        gameManager = FindObjectOfType<Game_Manager>();
        explosionSound = GameObject.Find("Explosion_sfx").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = new Vector3(Target.transform.position.x, transform.position.y, transform.position.z);
        Agent.SetDestination(targetPosition);
    }
    private void OnTriggerEnter(Collider other)
    {
        Health_script health = other.GetComponentInParent<Health_script>();

        if (health != null)
        {
            health.health -= damage;
            gameManager.UpdateHealth(health.gameObject, health.health);
            Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
            explosionSound.Play();
            Destroy(gameObject);
        }
    }
}
