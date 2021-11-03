using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uranus : MonoBehaviour
{
    // Planet attributes
    public float xSpeed = 5f;
    public float ySpeed = 20f;
    public float zSpeed = 10f;
    public float moveSpeed = 10f;
    private float screenOffset = 50f;

    private Rigidbody rb;
    private Vector3 screenBounds;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(-moveSpeed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the planets on their respective axis
        transform.Rotate(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, zSpeed * Time.deltaTime);

        // Removes game object if passed screen bounds
        if (transform.position.x < screenBounds.x - screenOffset)
        {
            UranusPool.Instance.AddToPool(gameObject);
        }
    }
}
