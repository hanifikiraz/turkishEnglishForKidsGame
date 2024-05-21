using System;
using System.Collections.Generic;
using UnityEngine;

namespace LevelScripts.RecyleGame
{
    public class RecyleManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> inAreas;

        private void OnEnable()
        {
            BusSystem.OnGoAreaValue += InAreasController;
        }

        private void OnDisable()
        {
            BusSystem.OnGoAreaValue -= InAreasController;
        }

        private void Start()
        {
            InAreasController(0);
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
