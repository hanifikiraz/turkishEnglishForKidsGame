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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SetTextAnim();
        }
    }

    private void SetTextAnim()
    {
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
            VARIABLE.gameObject.transform.DOScale(Vector3.zero, 0.2f);
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }
}

