using System;
using System.Collections.Generic;
using UnityEngine;

namespace LevelScripts.LetterGame
{
    public class LetterManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> wordsNoTransparent;
        [SerializeField] private List<GameObject> wordsTransparent;
        [SerializeField] private int maxWords;
        [SerializeField] private int completedValue;

        private int currentCompletedValue = 0;

        private void OnEnable()
        {
            BusSystem.OnLetterCompletedControl += LetterCompleted;
        }

        private void OnDisable()
        {
            BusSystem.OnLetterCompletedControl -= LetterCompleted;
        }

        private void Start()
        {
            SetLetter();
        }

        private void SetLetter()
        {
            foreach (var VARIABLE in wordsNoTransparent)
            {
                VARIABLE.SetActive(false);
            }
            foreach (var VARIABLE in wordsTransparent)
            {
                VARIABLE.SetActive(false);
            }
            wordsNoTransparent[currentCompletedValue].SetActive(true);
            wordsTransparent[currentCompletedValue].SetActive(true);
        }

        private void LetterCompleted()
        {
            currentCompletedValue++;
            
            if (currentCompletedValue>=completedValue)
            {
                Debug.Log("Level Bitti");
            }
            else
            {
                SetLetter();
            }
        }
    }
}
