using UnityEngine;

public class Drone_Script : MonoBehaviour
{
    public float damage = 20f;
    public Game_Manager gameManager;
    public GameObject particles;
    public AudioSource destruction_sfx;
    public GameObject player;
    public float moveSpeed;
    float diveDelay = 0.5f;
    bool diving = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        destruction_sfx = GameObject.Find("Explosion").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length > 0)
            {
            player = GameObject.FindGameObjectWithTag("Player");
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance > 5 && !diving)
            {
                SeekPlayer();
            }
            else
            {
                diving = true;
                Dive();
            }
        }
        if (Mathf.Abs(transform.position.y) > 100)
        {
            if (Mathf.Sign(transform.position.y) > 0)
            {
                print("Drone flew away");
            }
            else
            {
                print("Drone dug into the underworld");
            }
            Destroy(gameObject);
        }
        if (Mathf.Abs(transform.position.x) > int.MaxValue)
        {
            Destroy(gameObject);
            print("Drone left the confines of this world");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Health_script health = collision.gameObject.GetComponentInParent<Health_script>();

        if (health != null)
        {
            health.health -= damage;
            health.gameManager.UpdateHealth(health.gameObject, health.health);
            Instantiate(particles, transform.position, Quaternion.identity);
            destruction_sfx.Play();
            Destroy(gameObject);
        }
    }
    private void SeekPlayer()
    {
        transform.Translate(-Mathf.MoveTowards( transform.position.x, -1, player.transform.position.x  ), 0, -moveSpeed);
    }
    private void Dive()
    {
        diveDelay -= Time.deltaTime;
        if (diveDelay < 0)
        {
            transform.Translate(0, 0, -moveSpeed);
        }
        else
        {
            transform.Translate(0, -moveSpeed, -moveSpeed);
        }
        if (transform.position.y < 0)
        {
            Vector3 explosionPoint = new(transform.position.x, 0, transform.position.z);
            Instantiate(particles, explosionPoint, Quaternion.identity);
            destruction_sfx.Play();
            Destroy(gameObject);
            print("Drone destroyed");
        }
    }
}
