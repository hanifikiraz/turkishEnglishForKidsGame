using System.Collections.Generic;
using LevelScripts.AAAAAOthers;
using Menu.ClassMenuController;
using UnityEngine;

namespace Unit.UnitController
{
    public class UnitControllerClass1 : MonoBehaviour
    {
        [SerializeField] private List<GameObject> buttons;
        [SerializeField] private List<GameObject> buttonsGame;
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
            BusSystem.OnIncreaseCompletedUnitValueClassTwo += IncreaseLevelCompletedCount;
            BusSystem.OnUnitEnabled += SetValuesUnit;
            SetLockImage();
        }
    
        private void OnDisable()
        {
           BusSystem.OnIncreaseCompletedUnitValueClassTwo -= IncreaseLevelCompletedCount;
           BusSystem.OnUnitEnabled -= SetValuesUnit;
        }

        private void SetValuesUnit()
        {
            LoadLevelCompletion();
    
            SavePrefs();
            SetLockImage();
        }
    
        private void SetLockImage()
        {
                
            for (int i = 0; i < buttons.Count; i++)
            {
                if (i<=levelCompletedCount)
                {
                    buttons[i].GetComponent<ClassMenuControllerTwoClass>().LockGameObject.SetActive(false);
                }
            } 
            for (int i = 0; i < buttonsGame.Count; i++)
            {
                if (i<levelCompletedCount)
                {
                    buttonsGame[i].GetComponent<GameButtons>().lockObject.SetActive(false);
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
