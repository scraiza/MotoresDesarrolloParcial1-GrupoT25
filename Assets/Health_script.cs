using UnityEngine;

public class Health_script : MonoBehaviour
{
    public float health;
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
