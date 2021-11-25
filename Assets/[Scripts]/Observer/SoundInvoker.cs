using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundInvoker : MonoBehaviour
{
    //Implement Observer pattern action
    // Code referenced from Parisa's Lecture 4 Videos: https://drive.google.com/file/d/1mKuH4BzcJgqX2wQFOKWYbX6r7i3cS7mQ/view
    public static event Action start_Sound;


    // Start is called before the first frame update
    void Start()
    {
        //Invoking the Observer pattern
        //If the player falls below the death barrier, the death action is invoked.
       start_Sound?.Invoke();
    }
}
