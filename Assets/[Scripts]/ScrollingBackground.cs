using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    // Background Attributes
    public float scrollSpeed = -5f;
    private Vector3 startPos;
    public float maxLoopLength = 20f;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Position the parent background to the right of the child 
        float newPos = Mathf.Repeat(Time.time * scrollSpeed, maxLoopLength);
        transform.position = startPos + Vector3.right * newPos;
    }
}