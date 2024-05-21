using System;
using System.Collections.Generic;
using UnityEngine;

namespace LevelScripts.RecyleGame
{
    public class RecyleManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> inAreas;

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
            inAreas[value].SetActive(true);
        }
    }
}
