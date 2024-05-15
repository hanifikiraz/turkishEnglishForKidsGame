using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnswerController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI answerText;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SetTextAnim();
        }
    }

    private void SetTextAnim()
    {
        if (answerText != null)
        {
            // Metni al
            string text = answerText.text;

            // Her harfin boyutunu 12 yap
            answerText.fontSize = 0.35f;

            // Metindeki her harfi döngüyle işle
            StartCoroutine(TextAnim(text));

        }
        else
        {
            Debug.LogError("TextMeshProUGUI nesnesi atanmamış!");
        }
    }

    private IEnumerator TextAnim(string text)
    {
        for (int i = 0; i < text.Length; i++)
        {
            // Metindeki i. harfi seç
            int charIndex = answerText.textInfo.characterInfo[i].index;

            // Harfin font boyutunu 15 yap
            answerText.fontSize = 0.27f;

            // Tekrar meshi güncelle
            answerText.ForceMeshUpdate();
        }

        yield return new WaitForSecondsRealtime(0.1f);
    }
}

