using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    Vector3 startPos;
    public Vector3 endPos;

    float moveSpeed = 1f;

    private void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);
    
        if (transform.position.y >= endPos.y)
        {
            moveSpeed = -moveSpeed;
        }

        if (transform.position.y <= startPos.y)
        {
            moveSpeed = 1f;
        }
    }
}