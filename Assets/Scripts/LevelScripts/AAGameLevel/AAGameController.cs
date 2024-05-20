using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace LevelScripts.AAGameLevel
{
    public class AAGameController : MonoBehaviour
    {
        [SerializeField] private GameObject sphere;
        [SerializeField] private GameObject arrow;
        [SerializeField] private Transform arrowTransform;
        [SerializeField] private List<GameObject> closeObjects;
        [SerializeField] private List<GameObject> arrows;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private GameObject levelEndText;
        private bool levelEnd;

        private void OnEnable()
        {
            BusSystem.OnAAGameLevelEnd += LevelEnd;
        }

        private void OnDisable()
        {
            BusSystem.OnAAGameLevelEnd -= LevelEnd;
        }

        private void Update()
        {
            if (levelEnd == false)
            {
                sphere.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
            }
            
        }

        public void SetArrow()
        {
            GameObject instArrom = Instantiate(arrow, arrowTransform.position, Quaternion.identity);
            arrows.Add(instArrom);
        }

        private void LevelEnd()
        {
            levelEnd = true;
            foreach (var VARIABLE in closeObjects)
            {
                VARIABLE.transform.DOScale(Vector3.zero, 0.7f).OnComplete((() =>
                {
                    VARIABLE.SetActive(false);
                }));
            }

            foreach (var VARIABLE in arrows)
            {
             Destroy(VARIABLE);   
            }
            levelEndText.SetActive(true);
            levelEndText.transform.DOScale(Vector3.zero, 0);
            levelEndText.transform.DOScale(Vector3.one, 0.7f);
        }
        
    }
}
