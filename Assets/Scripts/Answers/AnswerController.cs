using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Answers
{
    public class AnswerController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI answerText;
        [SerializeField] private List<GameObject> answerButtons;
        [SerializeField] private int maxAnswerCount;
        [SerializeField] private GameObject buttonsBackGround;
        [SerializeField] private GameObject congText;
        [SerializeField] private GameObject particlesForWin;
        [SerializeField] private List<ParticleSystem> partic;
        [SerializeField] private List<string> objectNames;
        private int currentAnswerCount;

        private void OnEnable()
        {
            BusSystem.OnWrongAnswer += AnswerWrongController;
        }

        private void OnDisable()
        {
            BusSystem.OnWrongAnswer -= AnswerWrongController;
        }

        private void Start()
        {
            BusSystem.CallAudioChange(10);
            BusSystem.CallAudioChange(2);
            maxAnswerCount = answerButtons.Count;
            answerText.text = objectNames[currentAnswerCount];
            foreach (Transform childTransform in answerButtons[currentAnswerCount].transform)
            {
                GameObject childGameObject = childTransform.gameObject;
                childGameObject.GetComponent<ButtonSelection>().TweenAnimationLittle();
            }
        }

        private void AnswerWrongController(bool value)
        {
            if (value)
            {
                SetTextAnim();
            }
            else
            {
                answerText.color = Color.red;
                answerText.gameObject.transform.DOScale(new Vector3(1.5f,1.5f,1.5f), 0.5f).OnComplete(() =>
                {
                    answerText.gameObject.transform.DOScale(Vector3.one, 0.5f);
                    answerText.color = Color.white;
                });
            }
        }
    

        private void SetTextAnim()
        {
            answerText.color = Color.green;
            answerText.gameObject.transform.DOScale(new Vector3(1.5f,1.5f,1.5f), 1f).OnComplete(() =>
            {
                StartCoroutine(ButtonsAnim(answerButtons[currentAnswerCount].transform));
                currentAnswerCount++;
                
                if (currentAnswerCount == maxAnswerCount)
                {
                    StartCoroutine(TextAnim());
                }
                else
                {
                    answerText.color = Color.white;
                    answerText.gameObject.transform.DOScale(Vector3.zero, 0.3f).OnComplete((() =>
                    {
                        StartCoroutine(ButtonsAnimTwo(answerButtons[currentAnswerCount].transform));
                        answerText.text = objectNames[currentAnswerCount];
                        answerText.gameObject.transform.DOScale(new Vector3(1f, 1f, 1f), 0.5f);
                    }));
                }
            });
        
        }

        private IEnumerator ButtonsAnim(Transform but)
        {
            
            foreach (Transform childTransform in but)
            {
                GameObject childGameObject = childTransform.gameObject;

                childGameObject.GetComponent<ButtonSelection>().CloseAnimButtons();
                childGameObject.gameObject.transform.DOScale(Vector3.zero, 0.3f);
                yield return new WaitForSecondsRealtime(0.3f);
            }
            but.gameObject.SetActive(false);
        }
        private IEnumerator ButtonsAnimTwo(Transform but)
        {
                yield return new WaitForSecondsRealtime(0.7f);
                but.transform.gameObject.SetActive(true);
                foreach (Transform VARIABLE in but)
                {
                    GameObject childGameObject = VARIABLE.gameObject;
                    childGameObject.transform.localScale = Vector3.zero;
                }
                foreach (Transform childTransform in but)
                {
                    GameObject childGameObject = childTransform.gameObject;
                    childGameObject.gameObject.transform.DOScale(Vector3.one, 0.3f);
                    yield return new WaitForSecondsRealtime(0.3f);
                }
                foreach (Transform childTransform in but)
                {
                    GameObject childGameObject = childTransform.gameObject;
                    childGameObject.GetComponent<ButtonSelection>().TweenAnimationLittle();
                }
        }
        private IEnumerator TextAnim()
        {
            buttonsBackGround.transform.DOMoveY(-5, 1f);
            yield return new WaitForSecondsRealtime(0.4f);
            particlesForWin.SetActive(true);
            congText.SetActive(true);
            congText.gameObject.transform.DOScale(Vector3.zero, 0.7f).From().OnComplete((() =>
            {
                BusSystem.CallLevelWinStatusForCanvas(true);
            }));
            foreach (var VARIABLE in partic)
            {
                VARIABLE.Play();
            }
        }
    }
}

