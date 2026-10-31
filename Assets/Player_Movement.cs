using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour
{
    public float MovementSpeed = 50000;
    public Upgrade_Manager UpgradeManager;
    
    void Start()
    {
        UpgradeManager = FindObjectOfType<Upgrade_Manager>();
    }

    void Update()
    {
        GetComponent<Rigidbody>().AddTorque(new Vector3(-MovementSpeed*5, 0, 0) * Time.deltaTime);

        
        if (Input.GetButton("left"))
        {
            GetComponent<Rigidbody>().AddTorque(new Vector3(0, 0, -MovementSpeed*UpgradeManager.lateralSpeed) * Time.deltaTime);

        }
        if (Input.GetButton("right"))
        {
            GetComponent<Rigidbody>().AddTorque(new Vector3(0, 0, MovementSpeed*UpgradeManager.lateralSpeed) * Time.deltaTime);
        }
    }
}
