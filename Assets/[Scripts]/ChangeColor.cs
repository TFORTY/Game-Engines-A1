using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;



public class ChangeColor : MonoBehaviour
{

    [DllImport("ColorSwitch")]

	private static extern float incrementFloatValue(float value, float increment, float max);

    public float increment;

	private Material currentMaterial;

    private float H, S, V;

    // Start is called before the first frame update
    void Start()
    {
        currentMaterial = GetComponent<Renderer>().material;
        Invoke("changeColor", 0.1f);

    }

    void changeColor() 

        {

        Color.RGBToHSV(currentMaterial.color, out H, out S, out V);

        currentMaterial.color = Color.HSVToRGB(incrementFloatValue(H, increment, 1.0f), S, V);

        Invoke("changeColor", 0.1f);

        }
}
