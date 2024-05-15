using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class AnswerControllerForImageLevel : MonoBehaviour
{
    [SerializeField] private GameObject levelImage;
    [SerializeField] private List<GameObject> buttons;
    [SerializeField] private GameObject buttonsBackGround;
    [SerializeField] private GameObject congText;
    [SerializeField] private GameObject particlesForWin;
    [SerializeField] private List<ParticleSystem> partic;

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
        congText.gameObject.transform.DOScale(Vector3.zero, 0.7f).From();
        foreach (var VARIABLE in partic)
        {
            VARIABLE.Play();
        }
    }
}
