using UnityEngine;
using Cinemachine;

public class Camera_Follow : MonoBehaviour
{
    public Transform target;

    void Start()
    {
        CinemachineVirtualCamera virtualCamera = GetComponent<CinemachineVirtualCamera>();

        if (virtualCamera == null || target == null)
        {
            Debug.LogError("Falta asignar la cámara o el jugador.");
            return;
        }
        virtualCamera.Follow = target;
        virtualCamera.LookAt = target;
    }
}