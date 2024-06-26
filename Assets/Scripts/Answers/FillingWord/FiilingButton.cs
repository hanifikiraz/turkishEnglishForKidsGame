using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace Answers.FillingWord
{
    public class FiilingButton : MonoBehaviour
    {
        public enum Answer
        {
            False,
            True
        }
        
        [SerializeField] private Answer answerType;
        [SerializeField] private string buttonTextAnswer;
        [SerializeField] private TextMeshProUGUI buttonText;
        [SerializeField] private List<GameObject> myObjects;
        [SerializeField] private GameObject fillingText;
        [SerializeField] private GameObject emptyText;
        [SerializeField] private Image defaultImage;
        [SerializeField] private List<Sprite> sprites;
        private Tween scaleTween;

        private void OnDestroy()
        {
            scaleTween.Kill();
        }

        private void OnDisable()
        {
            scaleTween.Kill();
        }

        private void OnValidate()
        {
            buttonText.text = buttonTextAnswer;
            if (answerType == Answer.True)
            {
                gameObject.name = "TrueButton";
            }
            else
            {
                gameObject.name = "FalseButton";
            }
        }
        private void Start()
        {
            fillingText.SetActive(false);
            buttonText.text = buttonTextAnswer;
            SetButtonImage(1);
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
        public void TweenAnimationBig()
        {
            scaleTween = gameObject.transform.DOScale(Vector3.one, 0.8f).OnComplete(TweenAnimationLittle);
        }

        public void TweenAnimationLittle()
        {
            scaleTween = gameObject.transform.DOScale(new Vector3(0.9f, 0.9f, 0.9f), 0.8f)
                .OnComplete(TweenAnimationBig);
        }

        public void CloseAnimButtons()
        {
            scaleTween.Kill();
        }

        private void SetText()
        {
            emptyText.SetActive(false);
            fillingText.SetActive(true);
            BusSystem.CallCloseTweenButton();
            //CloseAnimButtons();
            fillingText.transform.DOScale(Vector3.zero, 0.5f).From().OnComplete((() =>
            {
                StartCoroutine(MyObjectClose());
            }));
        }
        private IEnumerator MyObjectClose()
        {
            yield return new WaitForSecondsRealtime(0.3f); 
            for (int i = 0; i < myObjects.Count; i++)
            {
                var VARIABLE = myObjects[i];
                VARIABLE.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
                yield return new WaitForSecondsRealtime(0.3f); 
               // Her objeden sonra 1 saniye bekle
            }
           // yield return new WaitForSecondsRealtime(0.3f); 
            BusSystem.CallFillingObjectWorked();
        }

        public void AnswerController()
        {
            ;
            switch (answerType)
            {
                case Answer.True:
                    BusSystem.CallAudioChange(8);
                    SetButtonImage(3);
                    Debug.Log("True");
                    BusSystem.CallPlayerSetAnim(3);
                    SetText();
                    break;
                case Answer.False:
                    BusSystem.CallAudioChange(9);
                    SetButtonImage(2);
                    Debug.Log("False");
                    BusSystem.CallPlayerSetAnim(2);
                    break;
            }
        }
    }
}
