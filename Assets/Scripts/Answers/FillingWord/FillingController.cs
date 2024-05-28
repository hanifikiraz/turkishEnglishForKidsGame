using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Answers.FillingWord
{
    public class FillingController : MonoBehaviour
    {
        [SerializeField] private List<TextMeshProUGUI> answerText;
        [SerializeField] private List<GameObject> answerButtons;
        [SerializeField] private GameObject congText;
        [SerializeField] private GameObject particlesForWin;
        [SerializeField] private List<ParticleSystem> partic;
        [SerializeField] private List<string> fillingWords;
        private int currentAnswerCount;
        private int maxAnswerCount;

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
            // maxAnswerCount = answerButtons.Count;
            // foreach (Transform childTransform in answerButtons[currentAnswerCount].transform)
            // {
            //     GameObject childGameObject = childTransform.gameObject;
            //     childGameObject.GetComponent<ButtonSelection>().TweenAnimationLittle();
            // }
        }

        private void AnswerWrongController(bool value)
        {
            // if (value)
            // {
            //     SetTextAnim();
            // }
            // else
            // {
            //     answerText[currentAnswerCount].color = Color.red;
            //     answerText[currentAnswerCount].gameObject.transform.DOScale(new Vector3(1.2f,1.2f,1.2f), 0.5f).OnComplete(() =>
            //     {
            //         answerText[currentAnswerCount].gameObject.transform.DOScale(Vector3.one, 0.5f);
            //         answerText[currentAnswerCount].color = Color.white;
            //     });
            // }
        }
    

        private void SetTextAnim()
        {
            answerText[currentAnswerCount].color = Color.green;
            answerText[currentAnswerCount].gameObject.transform.DOScale(new Vector3(1.2f,1.2f,1.2f), 1f).OnComplete(() =>
            {
                StartCoroutine(ButtonsAnim(answerButtons[currentAnswerCount].transform));
                currentAnswerCount++;
                
                if (currentAnswerCount == maxAnswerCount)
                {
                    StartCoroutine(TextAnim());
                }
                else
                {
                    answerText[currentAnswerCount].color = Color.white;
                    answerText[currentAnswerCount].gameObject.transform.DOScale(Vector3.zero, 0.3f).OnComplete((() =>
                    {
                        StartCoroutine(ButtonsAnimTwo(answerButtons[currentAnswerCount].transform));
                        answerText[currentAnswerCount].text = fillingWords[currentAnswerCount];
                        answerText[currentAnswerCount].gameObject.transform.DOScale(new Vector3(1f, 1f, 1f), 0.5f);
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
