using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class LevelPlayButtonCustomization : MonoBehaviour
    {
        public enum LevelType
        {
            KnowText,
            KnowImage,
            LevelPairing,
            LevelFilling
        }

        public GameObject LockGameObject;
        [SerializeField] private string unitName;
        [SerializeField] private Color color1;
        [SerializeField] private Color color2;
        [SerializeField] private List<Image> color1Images;
        [SerializeField] private List<Image> color2Images;
        [SerializeField] private List<string> levelTexts;
        [SerializeField] private TextMeshProUGUI levelTextMesh;
        [SerializeField] private LevelType levelType;
        [SerializeField] private List<GameObject> levelTypeImages;
        private int levelReply;
        private string key;

        private void Awake()
        {
            key = "LevelReply"+ unitName + gameObject.name;
            LoadLevelCompletion();
        }

        public void SetLevelIncrease()
        {
            if (levelReply == 0)
            {
                BusSystem.CallIncreaseCompletedLevelValue();
                levelReply = 1;
                SavePrefs();
            }
        }
        private void LoadLevelCompletion()
        {
            if (PlayerPrefs.HasKey(key))
            {
                levelReply = PlayerPrefs.GetInt(key);
            }
            else
            {
                levelReply = 0;
                PlayerPrefs.SetInt(key, levelReply);
                PlayerPrefs.Save(); // Değişiklikleri hemen kaydet
            }
            SavePrefs();
        }
        
        private void SetLevelType()
        {
            foreach (var VARIABLE in levelTypeImages)
            {
                VARIABLE.SetActive(false);
            }
            var numType = 0;
            switch (levelType)
            {
                case LevelType.KnowText:
                    numType = 0;
                    break;
                case LevelType.KnowImage:
                    numType = 1;
                    break;
                case LevelType.LevelPairing:
                    numType = 2;
                    break;
                case LevelType.LevelFilling:
                    numType = 3;
                    break;
            }
          //  levelTextMesh.text = levelTexts[numType];
            levelTypeImages[numType].SetActive(true);
        }
        private void OnValidate()
        {
            foreach (var VARIABLE in color1Images)
            {
                VARIABLE.color = color1;
            }
            foreach (var VARIABLE in color2Images)
            {
                VARIABLE.color = color2;
            }

            SetLevelType();
        }
        private void SavePrefs()
        {
            PlayerPrefs.SetInt(key, levelReply);
            PlayerPrefs.Save();
        }
    }
}
