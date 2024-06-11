using System;
using UnityEngine;
using DG.Tweening;

namespace LevelScripts.MovementLevel
{
    public class MovementGameController : MonoBehaviour
    {
        [SerializeField] private GameObject startButton;
        [SerializeField] private GameObject congText;
        [SerializeField] private GameObject failText;

        private void OnEnable()
        {
            BusSystem.OnLevelDone += LevelEnd;
        }

        private void OnDisable()
        {
            BusSystem.OnLevelDone -= LevelEnd;
        }

        public void StartGame()
        {
            startButton.SetActive(false);
            BusSystem.CallNewLevelStart();
        }
        private void LevelEnd(bool value)
        {
            if (value)
            {
                congText.SetActive(true);
                congText.transform.DOScale(Vector3.zero, 1f).From().OnComplete((() =>
                {
                    congText.SetActive(false);
                    BusSystem.CallLevelWinStatusForCanvas(true);
                }));
            }
            else
            {
                failText.SetActive(true);
                failText.transform.DOScale(Vector3.zero, 1f).From().OnComplete((() =>
                {
                    failText.SetActive(false);
                    BusSystem.CallLevelWinStatusForCanvas(false);
                }));
            }
        }
    }
}
