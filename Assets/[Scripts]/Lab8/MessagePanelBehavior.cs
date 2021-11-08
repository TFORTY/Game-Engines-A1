using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class MessagePanelBehavior : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageDisplay;
    [SerializeField] private float tweenTime;

    private Queue<string> messages = new Queue<string>();

    private void OnEnable()
    {
        Player.scoredPoint += PlayerScoredPoint;
    }

    private void OnDisable()
    {
        Player.scoredPoint -= PlayerScoredPoint;
    }
    private void Awake()
    {
        messageDisplay.rectTransform.localScale = new Vector3(0, 0, 0);
    }

    private void PlayerScoredPoint(string obj)
    {
        //messageDisplay.text = obj;
        //messageDisplay.rectTransform.localScale = new Vector3(1.7f, 1.7f, 1.7f);        
        //messageDisplay.rectTransform.DOScale(0, tweenTime);        
        messages.Enqueue(obj);        
        Debug.Log("Current queue length: "+ messages.Count.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        CheckQueue();
    }

    private void CheckQueue() 
    { 
        if (!DOTween.IsTweening(messageDisplay.rectTransform)) 
        { 
            if (messages.Count > 0) 
            { DisplayMessageAnimate(messages.Dequeue()); 
            } 
        } 
    }
    private void DisplayMessageAnimate(string obj) 
    { 
        messageDisplay.text = obj; 
        messageDisplay.rectTransform.localScale = new Vector3(1.7f, 1.7f, 1.7f); 
        messageDisplay.rectTransform.DOScale(0, tweenTime); 
    }
}