using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class ButtonSelection : MonoBehaviour
{
    public enum Answer
    {
        False,
        True
    }

    [SerializeField] private Answer answerType;
    [SerializeField] private string buttonTextAnswer;
    [SerializeField] private TextMeshProUGUI buttonText;
    private Tween scaleTween;

    private void Start()
    {
        buttonText.text = buttonTextAnswer;
        TweenAnimationLittle();
    }

    private void TweenAnimationBig()
    {
        scaleTween =  gameObject.transform.DOScale(Vector3.one, 0.8f).OnComplete(TweenAnimationLittle);
    }
    private void TweenAnimationLittle()
    {
        scaleTween = gameObject.transform.DOScale(new Vector3(0.9f,0.9f,0.9f), 0.8f).OnComplete(TweenAnimationBig);
    }

    public void CloseAnimButtons()
    {
        scaleTween.Kill();
    }

    public void AnswerController()
    {
        switch (answerType)
        {
            case Answer.True:
                Debug.Log("True");
                BusSystem.CallPlayerSetAnim(2);
                break;
            case Answer.False:
                Debug.Log("False");
                BusSystem.CallPlayerSetAnim(3);
                break;
        }
    }
}