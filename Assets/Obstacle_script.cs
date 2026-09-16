using UnityEngine;

public class Obstacle_script : MonoBehaviour
{
    public float damage = 10f;

    private void OnTriggerEnter(Collider other)
    {
        Health_script health = other.GetComponentInParent<Health_script>();

        if (health != null)
        {
            health.health -= damage;
            Destroy(gameObject);
        }
    }
}