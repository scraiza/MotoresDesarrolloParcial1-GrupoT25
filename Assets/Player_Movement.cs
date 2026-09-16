using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float MovementSpeed;
    
    void Update()
    {
        transform.Translate(0, 0, -MovementSpeed * Time.deltaTime);
        
        if (Input.GetButton("left"))
        {
            transform.Translate(MovementSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetButton("right"))
        {
            transform.Translate(-MovementSpeed * Time.deltaTime, 0, 0);
        }
    }
}
