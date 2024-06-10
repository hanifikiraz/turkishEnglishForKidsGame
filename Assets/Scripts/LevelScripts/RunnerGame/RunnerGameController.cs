using System;
using DG.Tweening;
using UnityEngine;

namespace LevelScripts.RunnerGame
{
    public class RunnerGameController : MonoBehaviour
    {
        [SerializeField] private GameObject congText;
        [SerializeField] private GameObject failText;
        [SerializeField] private GameObject startButton;
        [SerializeField] private GameObject jumpButton;

        private void OnEnable()
        {
            BusSystem.OnLevelDone += LevelEnd;
        }

        private void OnDisable()
        {
            BusSystem.OnLevelDone -= LevelEnd;
        }

        public void LevelStart()
        {
            jumpButton.SetActive(true);
            startButton.transform.DOScale(Vector3.zero, 0.3f);
            jumpButton.transform.DOScale(Vector3.zero, 0.3f).From();
            BusSystem.CallRunnerLevelStart();
        }

        public void Jump()
        {
            BusSystem.CallRunnerPlayerJump();
        }

        private void LevelEnd(bool value)
        {
            jumpButton.SetActive(false);
            if (value)
            {
                congText.SetActive(true);
                congText.transform.DOScale(Vector3.zero, 1f).From().OnComplete((() =>
                {
                    BusSystem.CallLevelWinStatusForCanvas(true);
                }));
            }
            else
            {
                failText.SetActive(true);
                failText.transform.DOScale(Vector3.zero, 1f).From().OnComplete((() =>
                {
                    BusSystem.CallLevelWinStatusForCanvas(false);
                }));
            }
        }
    }
}
