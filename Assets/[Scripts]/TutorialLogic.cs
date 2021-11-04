using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialLogic : MonoBehaviour
{
    public Text tutorialText;
    float timer = 0f;
    public Text timerText;
    bool text1 = false;
    bool text2 = false;
    bool text3 = false;
    bool text4 = false;
    bool text5 = false;
    bool text6 = false;
    bool text7 = false;

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

        if (timer >= 5)
        {
            tutorialText.text = "Along the way, colourful platforms will appear and you can earn points by matching your colour with the platforms!";
            text1 = true;
        }
        if (timer >= 10 && text1)
        {
            tutorialText.text = "Press SPACE to jump. Cmon, let's see you bounce!";
            text2 = true;
        }
        if (timer >= 15 && text2)
        {
            tutorialText.text = "To change colours, use the following keys!";
            text3 = true;
        }
        if (timer >= 18 && text3)
        {
            tutorialText.text = "Press I for RED!";
            text4 = true;
        }
        if (timer >= 21 && text4)
        {
            tutorialText.text = "Press O for BLUE!";
            text5 = true;
        }
        if (timer >= 24 && text5)
        {
            tutorialText.text = "Press P for YELLOW!";
            text6 = true;
        }
        if (timer >= 27 && text6)
        {
            tutorialText.text = "Nice! Hope you got the hang of it cause your adventure begins now!";
            text7 = true;
        }
        if (timer >= 32 && text7)
        {
            SceneManager.LoadScene("Game");
        }
    }
}