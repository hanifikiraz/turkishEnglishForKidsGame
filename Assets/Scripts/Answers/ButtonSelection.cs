using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        [SerializeField] private Image defaultImage;
        [SerializeField] private List<Sprite> sprites;
        private Tween scaleTween;
        private bool onClickable = true;
        
       
        private void OnEnable()
        {
            BusSystem.OnButtonClickable += ButtonClickable;
            onClickable = true;
        }

        private void OnDisable()
        {
            BusSystem.OnButtonClickable -= ButtonClickable;
        }
        private void Start()
        {
            buttonText.text = buttonTextAnswer;
            SetButtonImage(1);
            //TweenAnimationLittle();
        }

        private void SetButtonImage(int value)
        {
            switch (value)
            {
                case 1:
                    defaultImage.sprite = sprites[0];
                    break;
                case 2:
                    StartCoroutine(SetWrongImage());
                    break;
                case 3:
                    defaultImage.sprite = sprites[2];
                    break;
            }
        }

        private IEnumerator SetWrongImage()
        {
            defaultImage.sprite = sprites[1];
            yield return new WaitForSecondsRealtime(0.5f);
            defaultImage.sprite = sprites[0];
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
                switch (answerType)
                {
                    case Answer.True:
                        BusSystem.CallAudioChange(8);
                        SetButtonImage(3);
                        Debug.Log("True");
                        BusSystem.CallPlayerSetAnim(3);
                        BusSystem.CallWrongAnswer(true);
                        break;
                    case Answer.False:
                        BusSystem.CallAudioChange(9);
                        SetButtonImage(2);
                        Debug.Log("False");
                        BusSystem.CallPlayerSetAnim(2);
                        BusSystem.CallWrongAnswer(false);
                        break;
                }
            }
        }
    }
}