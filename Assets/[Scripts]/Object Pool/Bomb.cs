using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //Destroy(gameObject);
        BasicPool.Instance.AddToPool(gameObject);
    }
}