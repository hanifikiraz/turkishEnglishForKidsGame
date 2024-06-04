using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Answers
{
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
        private bool onClickable = true;
        
        private void Start()
        {
            buttonText.text = buttonTextAnswer;
            //TweenAnimationLittle();
        }

        private void OnEnable()
        {
            BusSystem.OnButtonClickable += ButtonClickable;
            onClickable = true;
        }

        private void OnDisable()
        {
            BusSystem.OnButtonClickable -= ButtonClickable;
        }

        private void ButtonClickable(bool value)
        {
            onClickable = value;
        }


        public void TweenAnimationBig()
        {
            scaleTween =  gameObject.transform.DOScale(Vector3.one, 0.8f).OnComplete(TweenAnimationLittle);
        }
        public void TweenAnimationLittle()
        {
            scaleTween = gameObject.transform.DOScale(new Vector3(0.9f,0.9f,0.9f), 0.8f).OnComplete(TweenAnimationBig);
        }

        public void CloseAnimButtons()
        {
            scaleTween.Kill();
        }

        public void AnswerController()
        {
            if (onClickable)
            {
                BusSystem.CallAudioChange(5);
                switch (answerType)
                {
                    case Answer.True:
                        Debug.Log("True");
                        BusSystem.CallPlayerSetAnim(3);
                        BusSystem.CallWrongAnswer(true);
                        break;
                    case Answer.False:
                        Debug.Log("False");
                        BusSystem.CallPlayerSetAnim(2);
                        BusSystem.CallWrongAnswer(false);
                        break;
                }
            }
        }
    }
}