using System;
using DG.Tweening;
using UnityEngine;

namespace LevelScripts.CollectFruits
{
    public class SpawnFruitsController : MonoBehaviour
    {
        [SerializeField] private float yPos;
        [SerializeField] private float yPosDuration;
        [SerializeField] private float point;
        private Tween goTween;
        
        private void OnEnable()
        {
            ObjectGoDown();
        }

        private void ObjectGoDown()
        {
            goTween =  gameObject.transform.DOLocalMoveY(yPos, yPosDuration);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "BasketFruit")
            {
                BusSystem.CallPlayerSetAnim(3);
                BusSystem.CallSetFruitScore(point);
                goTween.Kill();
                gameObject.GetComponent<Renderer>().enabled = false;
                Destroy(gameObject,1f);
            }
        }
    }
}
