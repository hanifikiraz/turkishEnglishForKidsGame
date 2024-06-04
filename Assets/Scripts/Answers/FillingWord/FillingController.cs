using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Answers.FillingWord
{
    public class FillingController : MonoBehaviour
    {
        [SerializeField] private List<GameObject> answerText;
        [SerializeField] private List<GameObject> answerButtons;
        [SerializeField] private GameObject congText;
        [SerializeField] private GameObject particlesForWin;
        [SerializeField] private List<ParticleSystem> partic;
        private int currentAnswerCount;
        private int maxAnswerCount;

        private void OnEnable()
        {
            BusSystem.OnFillingObjectWorked += FillingObjectController;
            BusSystem.OnCloseTweenButton += CloseTween;
        }

        private void OnDisable()
        {
            BusSystem.OnFillingObjectWorked -= FillingObjectController;
            BusSystem.OnCloseTweenButton -= CloseTween;
        }

        private void CloseTween()
        {
            foreach (Transform childTransform in answerButtons[currentAnswerCount].transform)
            {
                GameObject childGameObject = childTransform.gameObject;
                childGameObject.GetComponent<FiilingButton>().CloseAnimButtons();
            }
        }
        private void Start()
        {
            BusSystem.CallAudioChange(10);
            BusSystem.CallAudioChange(3);
            maxAnswerCount = answerButtons.Count;
            foreach (Transform childTransform in answerButtons[currentAnswerCount].transform)
            {
                GameObject childGameObject = childTransform.gameObject;
                childGameObject.GetComponent<FiilingButton>().TweenAnimationLittle();
            }
        }

        private void FillingObjectController()
        {
            answerButtons[currentAnswerCount].SetActive(false);
            answerText[currentAnswerCount].SetActive(false);
            currentAnswerCount++;

            if (currentAnswerCount == maxAnswerCount)
            {
                StartCoroutine(TextAnim());
            }
            else
            {
                answerButtons[currentAnswerCount].SetActive(true);
                answerText[currentAnswerCount].SetActive(true);
               
                StartCoroutine(ButtonsAnimTwo(answerButtons[currentAnswerCount].transform));
            }
        }
        
        private IEnumerator ButtonsAnimTwo(Transform but)
        {
            foreach (Transform VARIABLE in but)
            {
                GameObject childGameObject = VARIABLE.gameObject;
                childGameObject.transform.localScale = Vector3.zero;
            }
                yield return new WaitForSecondsRealtime(0.2f);
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
                    childGameObject.GetComponent<FiilingButton>().TweenAnimationLittle();
                }
        }
        private IEnumerator TextAnim()
        {
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
