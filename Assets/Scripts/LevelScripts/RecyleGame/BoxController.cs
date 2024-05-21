using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace LevelScripts.RecyleGame
{
    public class BoxController : MonoBehaviour
    {
        [SerializeField] private List<Transform> boxPosition;
        private bool isStart;

        private void Update()
        {
            if (isStart)
            {
              //  transform.position = new Vector3(transform.position.x, -0.184f, transform.position.z);
            }
        }

        public void GoBoxTween()
        {
            gameObject.transform.localRotation = boxPosition[0].transform.localRotation;
            gameObject.transform.DOLocalMove(boxPosition[0].localPosition, 0.4f).OnComplete((() =>
            {
                gameObject.transform.DOLocalMove(boxPosition[1].localPosition, 3f).OnComplete((() =>
                {
                    gameObject.transform.DOLocalMove(boxPosition[2].localPosition, 3f).OnComplete((() =>
                    {
                        gameObject.transform.DOLocalMove(boxPosition[3].localPosition, 2f).OnComplete((() =>
                        {
                            BusSystem.CallGoAreValue(2);
                            
                        }));
                    }));
                }));
            }));
        }
    }
}
