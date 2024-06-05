using System;
using UnityEngine;

namespace Unit
{
    public class UnitLevelController : MonoBehaviour
    {
        [SerializeField] private int unitType;
        [SerializeField] private string unitName;
        [SerializeField] private int totalLevelCount;
        private int levelCompletedCount;
        


        private void Awake()
        {
            if (PlayerPrefs.HasKey(unitName+unitType))
            {
                levelCompletedCount= PlayerPrefs.GetInt(unitName+unitType);
            }
            else
            {
                PlayerPrefs.SetInt(unitName+unitType, 0);
            }

            SavePrefs();
        }

        private void LevelController()
        {
            if (levelCompletedCount<totalLevelCount)
            {
                
            }
        }
        private void SavePrefs()
        {
            PlayerPrefs.SetInt(unitName+unitType, levelCompletedCount);
            PlayerPrefs.Save();
        }

    }
}
