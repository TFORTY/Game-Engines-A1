using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialLogic : MonoBehaviour
{
    public Text tutorialText;
    float timer = 0f;
    bool text1 = false;
    bool text2 = false;
    bool text3 = false;
    bool text4 = false;
    bool text5 = false;
    bool text6 = false;
    bool text7 = false;
    bool text8 = false;
    bool text9 = false;
    bool text10 = false;

    bool space = false;
    bool i = false;
    bool o = false;
    bool p = false;
    private bool dirty;
    bool starter;
    // Start is called before the first frame update
    void Start()
    {
        tutorialText.text = "Welcome to Rainbow Rhythm! This game is an endless runner/platformer hybrid where the goal is to reach the finish without falling!";
        dirty = false;
        starter = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        textChange();
        if(dirty)
            learning();
    }

    void learning()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&text1)
        {
            text1 = false;
            text2 = true;
            dirty = false;
            timer = 0;

        }
        if (Input.GetKeyDown(KeyCode.I)&&text3)
        {
            text3 = false;
            text4 = true;
            dirty = false;

        }
        if (Input.GetKeyDown(KeyCode.O)&&text4)//5
        {
            text4 = false;
            text5 = true;
            dirty = false;

        }
        if (Input.GetKeyDown(KeyCode.P)&&text5)//6
        {
            text5 = false;
            text6 = true;
            timer = 0;
            dirty = false;

        }
    }
    void textChange(){
        if (timer >= 5&& starter)//1
        {
            tutorialText.text = "Along the way, colourful platforms will appear and you can earn points by matching your colour with the platforms!";
            text1 = true;
            starter = false;
        }

        if (timer>=10 && text1)//2
        {
            tutorialText.text = "Press SPACE to jump. Cmon, let's see you bounce!";
            dirty = true;
        }
        if (text2)//3
        {
            tutorialText.text = "To change colours, use the following keys!";
            text3 = true;
            text2 = false;

        }
        if (timer >= 5 && text3)//4
        {
            tutorialText.text = "Press I for RED!";
            dirty = true;

        }
        if (text4)
        {
            tutorialText.text = "Press O for BLUE!";
            dirty = true;

        }

        if (text5)
        {
            tutorialText.text = "Press P for YELLOW!";
            dirty = true;

        }
        if (text6)//7
        {
            tutorialText.text = "Nice! Hope you got the hang of it cause your adventure begins now!";
            text7 = true;
            text6 = false;

        }

        if (timer >= 3 && text7)//8
        {
            tutorialText.text = "3";
            text8 = true;
            text7 = false;

        }
        if (timer >= 4 && text8)//9
        {
            tutorialText.text = "2";
            text9 = true;
            text8 = false;

        }
        if (timer >= 5 && text9)//10
        {
            tutorialText.text = "1";
            text10 = true;
            text9 = false;

        }
        if (timer >= 6 && text10)
        {
            SceneManager.LoadScene("Game");
        }
    }
}