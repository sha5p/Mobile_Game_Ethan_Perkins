using UnityEngine;

public class Parrlaxbackground : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        float parallaxEffectMuliplier = .5f;
        transform.position += deltaMovement * parallaxEffectMuliplier;
        lastCameraPosition = cameraTransform.position;
    }
}
