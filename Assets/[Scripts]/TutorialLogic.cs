using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialLogic : MonoBehaviour
{
    public Text tutorialText;
    float timer = 0f;
    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        tutorialText.text = "Welcome to Rainbow Rhythm! This game is an endless runner/platformer hybrid where the goal is to reach the finish without falling!";
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timerText.text = timer.ToString("0");
    }
}