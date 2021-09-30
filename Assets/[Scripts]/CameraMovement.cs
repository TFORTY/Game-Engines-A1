using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Camera Attributes
    public Transform target = null;

    private Vector3 offset;
    public float cameraSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        // Makes the camera follow the transform of the player smoothly
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, 0, target.position.z) + offset, Time.deltaTime * cameraSpeed);
    }
}