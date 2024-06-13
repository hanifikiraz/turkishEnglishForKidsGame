using System;
using DG.Tweening;
using UnityEngine;

namespace Engine
{
    public class InstantiateGameLevelManager : MonoBehaviour
    {
        [SerializeField] private GameObject allCanvas;
        [SerializeField] private GameObject gameLevelPrefabParent;
        [SerializeField] private GameObject gameWinCanvas;
        [SerializeField] private GameObject gameLoseCanvas;
        [SerializeField] private GameObject gameLoseWinCanvasBG;
        private GameObject playingGame;
        private GameObject playingGameForRetry;
        private GameObject lockObject;
        private bool isQuizLevel;
        private int level;

        private void OnEnable()
        {
            BusSystem.OnLevelWinStatusForCanvas += LevelWinStatusCanvas;
            BusSystem.OnCloseWinOrLoseCanvas += CloseWinOrLoseCanvas;
            BusSystem.OnSetIncreaseLevel += InstantiateGame;
            BusSystem.OnSetLevelNumber += LevelNumber;
            BusSystem.OnQuizLevel += IsQuizLevel;
        }

        private void OnDisable()
        {
            BusSystem.OnLevelWinStatusForCanvas -= LevelWinStatusCanvas;
            BusSystem.OnCloseWinOrLoseCanvas -= CloseWinOrLoseCanvas;
            BusSystem.OnSetIncreaseLevel -= InstantiateGame;
            BusSystem.OnSetLevelNumber -= LevelNumber;
            BusSystem.OnQuizLevel -= IsQuizLevel;
        }

        public void InstantiateGame(GameObject gameLevelPrefab)
        {
            SetLevel(gameLevelPrefab);
            
        }

        private void IsQuizLevel(bool value)
        {
            isQuizLevel = value;
        }

        private void LevelNumber(int value)
        {
            level = value;
            isQuizLevel = true;
            GameAnalyticInit.LogGameStart(value);
        }

        private void LevelEnd()
        {
            if (isQuizLevel)
            {
                GameAnalyticInit.LogGameOver(level,true,0);
            }
        }

        private void SetLevel(GameObject level)
        {
            allCanvas.SetActive(false);
            GameObject game = Instantiate(level, gameLevelPrefabParent.transform.position,
                Quaternion.identity);
            game.transform.SetParent(gameLevelPrefabParent.transform);
            playingGame = game;
            playingGameForRetry = level;
        }

        private void LevelWinStatusCanvas(bool isWin)
        {
            gameLoseWinCanvasBG.SetActive(true);
            if (isWin)
            {
                BusSystem.CallAudioChange(10);
                BusSystem.CallAudioChange(6);
                gameWinCanvas.SetActive(true);
                gameWinCanvas.transform.localScale = Vector3.zero;
                gameWinCanvas.transform.DOScale(Vector3.one,  0.7f);
            }
            else
            {
                BusSystem.CallAudioChange(10);
                BusSystem.CallAudioChange(7);
                gameLoseCanvas.SetActive(true);
                gameLoseCanvas.transform.localScale = Vector3.zero;
                gameLoseCanvas.transform.DOScale(Vector3.one,  0.7f);
            }
        }
        private void CloseWinOrLoseCanvas()
        {
            gameWinCanvas.SetActive(false);
            gameLoseCanvas.SetActive(false);
            gameLoseWinCanvasBG.SetActive(false);
        }
        public void HomeMenuButton()
        {
            BusSystem.CallAudioChange(1);
            allCanvas.SetActive(true);
            CloseWinOrLoseCanvas();
            Destroy(playingGame);
            LevelEnd();
        }
        public void RetryLevel()
        {
            CloseWinOrLoseCanvas();
            Destroy(playingGame);
            SetLevel(playingGameForRetry);
        }
    }
}
