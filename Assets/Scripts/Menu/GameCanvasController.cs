using System;
using LevelScripts.AAAAAOthers;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class GameCanvasController : MonoBehaviour
    {
        [SerializeField] private Image areaImage;
        [SerializeField] private Image areaImageTwo;
        public GameButtons.LevelType LevelType;
        private void OnEnable()
        {
            SetImage(false);
            if (LevelType != GameButtons.LevelType.Empty)
            {
                BusSystem.CallMiniLevelCompleted(LevelType);
                LevelType = GameButtons.LevelType.Empty;
            }
        }

        private void Start()
        {
            LevelType = GameButtons.LevelType.Empty;
        }
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
               // SetImage(true);
            }
            if (Input.GetMouseButtonUp(0))
            {
                SetImage(false);
            }
        }

        private void SetImage(bool value)
        {
            areaImage.enabled = value;
            areaImageTwo.enabled = value;
        }
    }
}
