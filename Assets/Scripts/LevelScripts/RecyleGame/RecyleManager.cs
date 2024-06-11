using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace LevelScripts.RecyleGame
{
    public class RecyleManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> inAreas;
        [SerializeField] private GameObject particlesToWin;
        [SerializeField] private List<ParticleSystem> particles;
        [SerializeField] private GameObject textWin;

        private void OnEnable()
        {
            BusSystem.OnGoAreaValue += InAreasController;
            BusSystem.OnRecyleLevelEnd += LevelEnd;
        }

        private void OnDisable()
        {
            BusSystem.OnGoAreaValue -= InAreasController;
            BusSystem.OnRecyleLevelEnd -= LevelEnd;
        }

        private void Start()
        {
            InAreasController(0);
            BusSystem.CallAudioChange(10);
            BusSystem.CallAudioChange(4);
        }

        private void LevelEnd()
        {
            particlesToWin.SetActive(true);
            foreach (var VARIABLE in particles)
            {
                VARIABLE.Play();
            }
            textWin.SetActive(true);
            textWin.transform.DOScale(Vector3.zero, 0);
            textWin.transform.DOScale(Vector3.one, 0.7f);
        }
        private void InAreasController(int value)
        {
           
            foreach (var VARIABLE in inAreas)
            {
                VARIABLE.SetActive(false);
            }
            if (value <5)
            {
                inAreas[value].SetActive(true);
            }
        }
    }
}
