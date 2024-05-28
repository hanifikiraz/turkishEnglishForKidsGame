using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

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
        private Tween scaleTween;
        
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
            CloseAnimButtons();
            fillingText.transform.DOScale(Vector3.zero, 0.5f).From().OnComplete((() =>
            {
                StartCoroutine(MyObjectClose());
            }));
        }
        private IEnumerator MyObjectClose()
        {
            yield return new WaitForSecondsRealtime(2f);
            foreach (var VARIABLE in myObjects)
            {
                VARIABLE.transform.DOScale(new Vector3(0,0,0),1f);
            }
            BusSystem.CallFillingObjectWorked();
        }

        public void AnswerController()
        {
            switch (answerType)
            {
                case Answer.True:
                    Debug.Log("True");
                    BusSystem.CallPlayerSetAnim(2);
                    SetText();
                   // BusSystem.CallWrongAnswer(true);
                    break;
                case Answer.False:
                    Debug.Log("False");
                    BusSystem.CallPlayerSetAnim(3);
                    //BusSystem.CallWrongAnswer(false);
                    break;
            }
        }
    }
}
