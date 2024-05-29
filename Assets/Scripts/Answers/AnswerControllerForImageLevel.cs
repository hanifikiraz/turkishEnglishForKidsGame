using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Answers
{
    public class AnswerControllerForImageLevel : MonoBehaviour
    {
        [SerializeField] private GameObject levelImage;
        [SerializeField] private List<GameObject> answerButtons;
        [SerializeField] private GameObject buttonsBackGround;
        [SerializeField] private GameObject congText;
        [SerializeField] private GameObject particlesForWin;
        [SerializeField] private List<ParticleSystem> partic;
        [SerializeField] private List<Sprite> objectSprites;
        [SerializeField] private Image defaultImage;
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
            BusSystem.CallAudioChange(10);
            BusSystem.CallAudioChange(3);
            maxAnswerCount = answerButtons.Count;
            defaultImage.sprite = objectSprites[currentAnswerCount];
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
                levelImage.gameObject.transform.DOScale(new Vector3(1.3f,1.3f,1.3f), 0.5f).OnComplete(() =>
                {
                    levelImage.gameObject.transform.DOScale(Vector3.one, 0.5f);
                });
            }
        }
    

        private void SetTextAnim()
        {
        
        
            levelImage.gameObject.transform.DOScale(new Vector3(1.3f,1.3f,1.3f), 1f).OnComplete(() =>
            {
                StartCoroutine(ButtonsAnim(answerButtons[currentAnswerCount].transform));
                currentAnswerCount++;
                if (currentAnswerCount == maxAnswerCount)
                {
                    StartCoroutine(TextAnim());
                }
                else
                {
                    
                    defaultImage.gameObject.transform.DOScale(Vector3.zero, 0.3f).OnComplete((() =>
                    {
                        StartCoroutine(ButtonsAnimTwo(answerButtons[currentAnswerCount].transform));
                        defaultImage.sprite = objectSprites[currentAnswerCount];
                        defaultImage.gameObject.transform.DOScale(new Vector3(1f, 1f, 1f), 0.5f);
                    }));
                }
                
            });
        
        }
        private IEnumerator TextAnim()
        {
            buttonsBackGround.transform.DOMoveY(-5, 1f);
            yield return new WaitForSecondsRealtime(0.4f);
            particlesForWin.SetActive(true);
            congText.SetActive(true);
            congText.gameObject.transform.DOScale(new Vector3(0,0,0), 0.7f).From().OnComplete((() =>
            {
                BusSystem.CallLevelWinStatusForCanvas(true);
            }));
            foreach (var VARIABLE in partic)
            {
                VARIABLE.Play();
            }
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
    }
}
