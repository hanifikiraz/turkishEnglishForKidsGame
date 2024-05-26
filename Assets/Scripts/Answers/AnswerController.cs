using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class AnswerController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI answerText;
    [SerializeField] private List<GameObject> buttons;
    [SerializeField] private GameObject buttonsBackGround;
    [SerializeField] private GameObject congText;
    [SerializeField] private GameObject particlesForWin;
    [SerializeField] private List<ParticleSystem> partic;
    public List<List<GameObject>> objectss;

    private void OnEnable()
    {
        BusSystem.OnWrongAnswer += AnswerWrongController;
    }

    private void OnDisable()
    {
        BusSystem.OnWrongAnswer -= AnswerWrongController;
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
            StartCoroutine(TextAnim());
        });
        
    }
    private IEnumerator TextAnim()
    {
        buttonsBackGround.transform.DOMoveY(-5, 1f);
        yield return new WaitForSecondsRealtime(0.4f);
        
        foreach (var VARIABLE in buttons)
        {
            VARIABLE.GetComponent<ButtonSelection>().CloseAnimButtons();
            VARIABLE.gameObject.transform.DOScale(Vector3.zero, 0.3f);
            yield return new WaitForSecondsRealtime(0.3f);
        }
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

    public void CloseCanvas()
    {
        
    }
}

