using System;
using System.Collections.Generic;
using UnityEngine;

namespace LevelScripts.LetterGame
{
    public class LetterControl : MonoBehaviour
    {
        [SerializeField] private List<GameObject> letters;
        [SerializeField] private Material lettersMaterial;
        private bool isCompleted;

        private void OnEnable()
        {
            BusSystem.OnMaterialControlLetter += LetterMaterialController;
        }

        private void OnDisable()
        {
            BusSystem.OnMaterialControlLetter -= LetterMaterialController;
        }

        private void LetterMaterialController()
        {
            bool allDifferent = true;

            foreach (var VARIABLE in letters)
            {
                if (VARIABLE.GetComponent<LetterSelection>().isCompleted == false)
                {
                    allDifferent = false;
                    break; 
                }
            }

            isCompleted = allDifferent;

            if (isCompleted)
            {
                Debug.Log("Bittttttttiii");
            }
        }
    }
}
