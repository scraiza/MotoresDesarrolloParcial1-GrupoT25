using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour
{
    public float MovementSpeed = 50000;

    void Update()
    {
        GetComponent<Rigidbody>().AddTorque(new Vector3(-MovementSpeed*5, 0, 0) * Time.deltaTime);

        
        if (Input.GetButton("left"))
        {
            GetComponent<Rigidbody>().AddTorque(new Vector3(0, 0, -MovementSpeed*10) * Time.deltaTime);

        }
        if (Input.GetButton("right"))
        {
            GetComponent<Rigidbody>().AddTorque(new Vector3(0, 0, MovementSpeed*10) * Time.deltaTime);
        }
    }
}
