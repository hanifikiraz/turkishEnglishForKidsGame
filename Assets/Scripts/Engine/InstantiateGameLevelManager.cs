using System;
using DG.Tweening;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

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

        private void OnEnable()
        {
            BusSystem.OnLevelWinStatusForCanvas += LevelWinStatusCanvas;
            BusSystem.OnCloseWinOrLoseCanvas += CloseWinOrLoseCanvas;
        }

        private void OnDisable()
        {
            BusSystem.OnLevelWinStatusForCanvas -= LevelWinStatusCanvas;
            BusSystem.OnCloseWinOrLoseCanvas -= CloseWinOrLoseCanvas;
        }

        public void InstantiateGame(GameObject gameLevelPrefab)
        {
            SetLevel(gameLevelPrefab);
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
                gameWinCanvas.transform.DOScale(new UnityEngine.Vector3(0,0,0), 0.7f).From();
            }
            else
            {
                BusSystem.CallAudioChange(10);
                BusSystem.CallAudioChange(7);
                gameLoseCanvas.SetActive(true);
                gameLoseCanvas.transform.DOScale(new UnityEngine.Vector3(0,0,0), 0.7f).From();
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
        }
        public void RetryLevel()
        {
            CloseWinOrLoseCanvas();
            Destroy(playingGame);
            SetLevel(playingGameForRetry);
        }
    }
}
