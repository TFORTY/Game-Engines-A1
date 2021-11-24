using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ApplyRandomScale : MonoBehaviour
{
    [DllImport("RandomScaleValue.dll")]
    private static extern float RandomScaleValue(float minValue, float maxValue);

    [SerializeField] float minRandomFactor = 0.95f;
    [SerializeField] float maxRandomFactor = 1.5f;

    void Start()
    {
        transform.localScale = new Vector3(transform.localScale.x * RandomScaleValue(minRandomFactor, maxRandomFactor), transform.localScale.y, transform.localScale.z);    
    }
}
