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
        private GameObject playingGame;
        private GameObject playingGameForRetry;

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
            allCanvas.SetActive(false);
            GameObject game = Instantiate(gameLevelPrefab, gameLevelPrefabParent.transform.position,
                Quaternion.identity);
            game.transform.SetParent(gameLevelPrefabParent.transform);
            playingGame = game;
            playingGameForRetry = gameLevelPrefab;
        }

        private void LevelWinStatusCanvas(bool isWin)
        {
            if (isWin)
            {
                gameWinCanvas.SetActive(true);
                gameWinCanvas.transform.DOScale(new UnityEngine.Vector3(0,0,0), 0.7f).From();
            }
            else
            {
                gameLoseCanvas.SetActive(true);
                gameLoseCanvas.transform.DOScale(new UnityEngine.Vector3(0,0,0), 0.7f).From();
            }
        }
        private void CloseWinOrLoseCanvas()
        {
            gameWinCanvas.SetActive(false);
            gameLoseCanvas.SetActive(false);
        }
        public void HomeMenuButton()
        {
            allCanvas.SetActive(true);
            CloseWinOrLoseCanvas();
            Destroy(playingGame);
        }
        public void RetryLevel()
        {
            CloseWinOrLoseCanvas();
            Destroy(playingGame);
            InstantiateGame(playingGameForRetry);
        }
    }
}
