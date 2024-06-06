using System;
using System.Collections.Generic;
using UnityEngine;

namespace LevelScripts.AAAAAOthers
{
    public class GameButtons : MonoBehaviour
    {
        public enum LevelType
        {
            Tank,
            Fruit,
            AA,
            Jump,
            Recyle,
            Letter,
            Minefield
            
        }

        [SerializeField] private List<GameObject> levelImages;
        [SerializeField] private GameObject lockObject;
        public LevelType levelType;

        private void OnValidate()
        {
            SetLevelType();
        }

        private void SetImage(int value)
        {
            foreach (var VARIABLE in levelImages)
            {
                VARIABLE.SetActive(false);
            }
            levelImages[value].SetActive(true);
        }
        private void SetLevelType()
        {
            switch (levelType)
            {
                case LevelType.Tank:
                    SetImage(0);
                    break;
                case LevelType.Fruit:
                    SetImage(1);
                    break;
                case LevelType.AA:
                    SetImage(2);
                    break;
                case LevelType.Jump:
                    SetImage(3);
                    break;
                case LevelType.Recyle:
                    SetImage(4);
                    break;
                case LevelType.Letter:
                    SetImage(5);
                    break;
                case LevelType.Minefield:
                    SetImage(6);
                    break;
            }
        }
    }
}
