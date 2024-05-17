using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = System.Numerics.Vector3;

namespace LevelScripts.CollectFruits
{
    public class FruitsSpawnManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> spawnPoses;
        [SerializeField] private List<GameObject> spawnObject;
        [SerializeField] private List<GameObject> moveButtons;
        [SerializeField] private GameObject startButton;
        [SerializeField] private GameObject congText;
        [SerializeField] private GameObject particle;
        [SerializeField] private List<ParticleSystem> particles;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private float spawnDuration;
        [SerializeField] private float endScore;
        private float score;
        private bool levelEnd;
        
        private void OnEnable()
        {
            BusSystem.OnSetFruitScore += SetScore;
        }

        private void OnDisable()
        {
            BusSystem.OnSetFruitScore -= SetScore;
        }

        private void Start()
        {
            SetScore(0);
        }

        private void SetScore(float value)
        {
            score += value;
            scoreText.text = score.ToString();
            if (score == endScore)
            {
                levelEnd = true;
                StopCoroutine(SpawnObjectCoroutine());
                congText.SetActive(true);
                congText.transform.DOScale(new UnityEngine.Vector3(0,0,0), 0.7f).From();
                particle.SetActive(true);
                foreach (var VARIABLE in particles)
                {
                    VARIABLE.Play();
                }

                foreach (var VARIABLE in moveButtons)
                {
                    VARIABLE.SetActive(false);
                }
            }
        }

        public void StartGame()
        {
            startButton.gameObject.transform.DOScale(new UnityEngine.Vector3(0,0,0), 0.5f).OnComplete((() =>
            {
               
                startButton.SetActive(false);
                foreach (var VARIABLE in moveButtons)
                {
                    VARIABLE.SetActive(true);
                    VARIABLE.transform.DOScale(new UnityEngine.Vector3(0,0,0), 0.7f).From();
                }
                StartCoroutine(SpawnObjectCoroutine());
            }));
            
        }

        private void SpawnObject()
        {
            if (levelEnd == false)
            {
                int randomFruit = Random.Range(0, spawnObject.Count);
                int randomFruitPos = Random.Range(0, spawnPoses.Count);
                GameObject instantFruit = Instantiate(spawnObject[randomFruit], spawnPoses[randomFruitPos].transform.position, Quaternion.identity);
            }
            
        }

        private IEnumerator SpawnObjectCoroutine()
        {
            SpawnObject();
            yield return new WaitForSecondsRealtime(spawnDuration);
            StartCoroutine(SpawnObjectCoroutine());
        }
    }
}
