using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace LevelScripts.TankLevel
{
    public class TankLevelController : MonoBehaviour
    {
        [SerializeField] private GameObject congText;
        [SerializeField] private List<GameObject> buttons;
        [SerializeField] private int objectValue;
        private int currentObjectValue;
        private void OnEnable()
        {
            BusSystem.OnMovingObjectBomb += MovingObjectSetBomb;
        }

        private void OnDisable()
        {
            BusSystem.OnMovingObjectBomb -= MovingObjectSetBomb;
        }

        private void Start()
        {
            currentObjectValue = objectValue;
        }

        private void MovingObjectSetBomb()
        {
            currentObjectValue--;
            
            if (currentObjectValue == 0)
            {
                foreach (var VARIABLE in buttons)
                {
                    VARIABLE.SetActive(false);
                }
                congText.SetActive(true);
                congText.transform.DOScale(Vector3.zero, 0.7f).From();
            }
            
        }
    }
}
