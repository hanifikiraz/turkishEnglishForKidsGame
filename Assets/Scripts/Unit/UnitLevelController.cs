using System;
using System.Collections.Generic;
using Menu;
using UnityEngine;

namespace Unit
{
    public class UnitLevelController : MonoBehaviour
    {
        [SerializeField] private List<GameObject> buttons;
        [SerializeField] private int unitType;
        [SerializeField] private string unitName;
        [SerializeField] private int totalLevelCount;
        private int levelCompletedCount;
        
        
        private void LoadLevelCompletion()
        {
            string key = unitName + unitType;

            if (PlayerPrefs.HasKey(key))
            {
                levelCompletedCount = PlayerPrefs.GetInt(key);
            }
            else
            {
                levelCompletedCount = 0;
                PlayerPrefs.SetInt(key, levelCompletedCount);
                PlayerPrefs.Save(); // Değişiklikleri hemen kaydet
            }

            Debug.Log("Level Completed Count: " + levelCompletedCount);
        }

        private void Awake()
        {
            LoadLevelCompletion();

            SavePrefs();
            SetLockImage();
        }

        private void OnEnable()
        {
            BusSystem.OnIncreaseCompletedLevelValue += IncreaseLevelCompletedCount;
            SetLockImage();
        }

        private void OnDisable()
        {
            BusSystem.OnIncreaseCompletedLevelValue -= IncreaseLevelCompletedCount;
        }

        private void SetLockImage()
        {
            
            for (int i = 0; i < buttons.Count; i++)
            {
                if (i<=levelCompletedCount)
                {
                    buttons[i].GetComponent<LevelPlayButtonCustomization>().LockGameObject.SetActive(false);
                }
            }
        }

        private void IncreaseLevelCompletedCount()
        {
            levelCompletedCount++;
            SavePrefs();
        }
        private void SavePrefs()
        {
            PlayerPrefs.SetInt(unitName+unitType, levelCompletedCount);
            PlayerPrefs.Save();
        }

    }
}
