using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class Drone_Script_Test : MonoBehaviour
{
    public Transform Target;
    public NavMeshAgent agent;
    public float damage = 20f;
    public Game_Manager gameManager;
    public GameObject explosionEffectPrefab;
    public AudioSource explosionSound;

    void Start()
    {
        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
        }

        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            Target = playerObj.transform;
        }

        gameManager = FindObjectOfType<Game_Manager>();

        GameObject sfxObj = GameObject.Find("Explosion_sfx");
        if (sfxObj != null)
        {
            explosionSound = sfxObj.GetComponent<AudioSource>();
        }

        if (agent != null)
        {
            NavMeshHit hit;
            if (NavMesh.SamplePosition(transform.position, out hit, 5.0f, NavMesh.AllAreas))
            {
                agent.Warp(hit.position);
            }
        }
    }

    void Update()
    {
        if (agent != null && Target != null && agent.enabled)
        {
            agent.SetDestination(Target.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Health_script health = other.GetComponentInParent<Health_script>();

        if (health != null)
        {
            health.health -= damage;

            if (gameManager != null)
            {
                gameManager.UpdateHealth(health.gameObject, health.health);
            }

            if (explosionEffectPrefab != null)
            {
                Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
            }

            if (explosionSound != null)
            {
                explosionSound.Play();
            }

            Destroy(gameObject);
        }
    }
}