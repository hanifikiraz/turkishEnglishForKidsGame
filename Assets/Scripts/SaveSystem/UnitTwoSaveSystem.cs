using System;
using System.Collections.Generic;
using Menu;
using UnityEngine;

namespace SaveSystem
{
    public class UnitTwoSaveSystem : MonoBehaviour
    {
        private bool isLevelReply;
        private int completedLevelValue;
        [SerializeField] private List<GameObject> levelButtons;
        
        private string key;
        private int playingLevelValue;
        private bool isIncreaseLevel;
        private LevelPlayButtonCustomization custom;


        private void OnEnable()
        {
            BusSystem.OnLevelReply += IsLevelReply;
            BusSystem.OnLevelPlayCustomization += Custom;
        }

        private void OnDisable()
        {
            BusSystem.OnLevelReply -= IsLevelReply;
            BusSystem.OnLevelPlayCustomization -= Custom;
        }

        private void Custom(LevelPlayButtonCustomization value)
        {
            custom = value;
        }
        private void Awake()
        {
            key = "CompletedLevelValueUnitTwo";
            LoadLevelCompletion();
        }

        private void IsLevelReply(bool value)
        {
            isLevelReply = value;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                custom.LogAAA();
            }
        }


        private void LoadLevelCompletion()
        {
            if (PlayerPrefs.HasKey(key))
            {
                completedLevelValue = PlayerPrefs.GetInt(key);
            }
            else
            {
                completedLevelValue = 0;
                PlayerPrefs.SetInt(key, completedLevelValue);
                PlayerPrefs.Save(); // Değişiklikleri hemen kaydet
            }
            SavePrefs();
        }

       

        private void SetIncreaseCompletedValue()
        {
            if (isLevelReply == false)
            {
                completedLevelValue++;
                SavePrefs();
            }
        }

        private void SetLevels()
        {
            for (int i = 0; i < completedLevelValue; i++)
            {
                levelButtons[i].GetComponent<LevelPlayButtonCustomization>().LockGameObject.SetActive(false);
            }
        }
        private void SavePrefs()
        {
            PlayerPrefs.SetInt(key, completedLevelValue);
            PlayerPrefs.Save();
        }
    }
}
