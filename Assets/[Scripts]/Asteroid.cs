using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : Planet
{
    // Update is called once per frame
    void Update()
    {
        // Rotate the planets on their respective axis
        transform.Rotate(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, zSpeed * Time.deltaTime);

        // Removes game object if passed screen bounds
        if (transform.position.x < screenBounds.x - screenOffset)
        {
            AsteroidPool.Instance.AddToPool(gameObject);
        }
    }
}