using System;
using System.Collections.Generic;
using Menu;
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
            Minefield,
            DoubleSides,
            Runner,
            Movement,
            Empty
        }
        
        [SerializeField] private int id;
        [SerializeField] private List<GameObject> levelImages;
        [SerializeField] private List<GameObject> levels;
        [SerializeField] private GameObject gamePrefab;
        [SerializeField] private GameCanvasController canvasController;
        public GameObject lockObject;
        public LevelType levelType;
        private string prefName;
        private int levelCompleted;
        

        private void OnValidate()
        {
            SetLevelType();
        }

        private void OnEnable()
        {
            BusSystem.OnMiniLevelCompleted += LevelCompletedController;
        }

        private void OnDisable()
        {
            BusSystem.OnMiniLevelCompleted -= LevelCompletedController;
        }

        private void Awake()
        {
            prefName = levelType.ToString() + id;
            
            if (PlayerPrefs.HasKey(prefName))
            {
                levelCompleted = PlayerPrefs.GetInt(prefName);
            }
            else
            {
                levelCompleted = 0;
                PlayerPrefs.SetInt(prefName, levelCompleted);
                PlayerPrefs.Save(); // Değişiklikleri hemen kaydet
            }
        }

        private void LevelCompletedController(LevelType levelTypeGet)
        {
            if (levelTypeGet == levelType)
            {
                levelCompleted++;
                if (levelCompleted >= levels.Count)
                {
                    levelCompleted = 0;
                }
                SavePrefs();
            }
        }

        public void SetGameInstantiate()
        {
            BusSystem.CallQuizLevel(false);
            canvasController.LevelType = levelType;
            BusSystem.CallSetIncreaseLevel(levels[levelCompleted]);
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
                case LevelType.DoubleSides:
                    SetImage(7);
                    break;
                case LevelType.Runner:
                    SetImage(8);
                    break;
                case LevelType.Movement:
                    SetImage(9);
                    break;
            }
        }
        private void SavePrefs()
        {
            PlayerPrefs.SetInt(prefName,levelCompleted);
            PlayerPrefs.Save();
        }
    }
}
