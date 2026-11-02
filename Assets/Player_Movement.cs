using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour
{
    public float MovementSpeed = 50000;
    public Upgrade_Manager UpgradeManager;
    public float LateralDrag = 5f;

    private Rigidbody rb;

    void Start()
    {
        UpgradeManager = FindObjectOfType<Upgrade_Manager>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddTorque(new Vector3(-MovementSpeed * 5, 0, 0) * Time.deltaTime);

        float forwardSpeedFactor = Mathf.Abs(rb.angularVelocity.x);
        forwardSpeedFactor = Mathf.Max(forwardSpeedFactor, 1f);

        if (Input.GetButton("left"))
        {
            float lateralTorque = MovementSpeed * UpgradeManager.lateralSpeed + forwardSpeedFactor;
            rb.AddTorque(new Vector3(0, 0, -lateralTorque) * Time.deltaTime);
        }
        else if (Input.GetButton("right"))
        {
            float lateralTorque = MovementSpeed * UpgradeManager.lateralSpeed + forwardSpeedFactor;
            rb.AddTorque(new Vector3(0, 0, lateralTorque) * Time.deltaTime);
        }
        else 
        {
            Vector3 currentAngularVelocity = rb.angularVelocity;
            currentAngularVelocity.z = Mathf.Lerp(currentAngularVelocity.z, 0f, LateralDrag * Time.deltaTime);
            rb.angularVelocity = currentAngularVelocity;
        }
    }
}