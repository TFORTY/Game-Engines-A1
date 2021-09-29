using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public float xSpeed = 0f;
    public float ySpeed = 0f;
    public float zSpeed = 0f;
    public float moveSpeed = 10f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(-moveSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate( xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, zSpeed * Time.deltaTime);
    }
}