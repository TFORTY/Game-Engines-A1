using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SoundEffectManager : MonoBehaviour
{

    //Create a variable to store audio clip
    private AudioSource _audioSource;


    // Start is called before the first frame update
    private void Awake()
    {

     
        //_audioSource variable grabs AudioSource component;
        _audioSource = GetComponent<AudioSource>();

        Debug.Log("Audio is played");

        //Action from the player class is referenced and used to playaudio 
        Player.is_Dead += PlayAudio;


        //This section of code was referenced: https://docs.unity3d.com/ScriptReference/Object.DontDestroyOnLoad.html
        //Create an array of the GameObject that looks for gameobjects with the tag "Sound Effects"
        GameObject[] soundEffect = GameObject.FindGameObjectsWithTag("Sound Effects");

        ////This if statement will destroy the music game object if it has already been created
        ////When switching from the lose screen back to the game screen, the 'soundEffect' variable will be greater then 1.Therefore, we destroy the object so the '_audioSource' will be re-invoked without a null value
        if (soundEffect.Length > 1)
        {
            Destroy(this.gameObject);
        }

        ////If the amount of game objects is less then or equal to one, the object with the music tag is not destroyed
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }


    }

    public void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {

            //Audio source component stops playing when reutrning back to the game scene
            _audioSource.Stop();

        }

    }

    private void PlayAudio()
    {
        //The audiosource variable calls the play function. This function will play the audio attached to the audio source component
        _audioSource.Play();
    }

    //private void StopAudio()
    //{

    //}
}
