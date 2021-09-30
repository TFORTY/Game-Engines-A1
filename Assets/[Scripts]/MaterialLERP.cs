using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// References Used:
// https://docs.unity3d.com/ScriptReference/Material.Lerp.html

public class MaterialLERP : MonoBehaviour
{
    // Material Attributes
    public Material mat1;
    public Material mat2;
    public float duration = 2f;
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();

        rend.material = mat1;
    }

    // Update is called once per frame
    void Update()
    {
        // Lerps the colour of the object based on two materials provided
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        rend.material.Lerp(mat1, mat2, lerp);
    }
}