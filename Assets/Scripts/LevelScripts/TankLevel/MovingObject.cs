using System;
using DG.Tweening;
using UnityEngine;

namespace LevelScripts.TankLevel
{
    public class MovingObject : MonoBehaviour
    {
        public enum MovingSelection
        {
            Right,
            Left
        }
        [SerializeField] private GameObject mainObject;
        [SerializeField] private GameObject leftObject;
        [SerializeField] private GameObject rightObject;
        [SerializeField] private ParticleSystem partic;
        [SerializeField] private Transform particPos;
        [SerializeField] private float movingDuration;
        public MovingSelection movSelect;
        
        private Tween moveTween;

        private void Start()
        {
            switch (movSelect)
            {
                case MovingSelection.Left:
                    SetMoveLeft();
                    break;
                case MovingSelection.Right:
                    SetMoveRight();
                    break;
            }
        }

        private void SetMoveLeft()
        {
            moveTween =  mainObject.transform.DOLocalMove(leftObject.transform.localPosition, movingDuration).OnComplete(SetMoveRight);
        }
        private void SetMoveRight()
        {
            moveTween = mainObject.transform.DOLocalMove(rightObject.transform.localPosition, movingDuration).OnComplete(SetMoveLeft);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Bullet")
            {
                BusSystem.CallMovingObjectBomb();
                moveTween.Kill();
                ParticleSystem insPartic = Instantiate(partic, particPos.position, Quaternion.identity);
                insPartic.Play();
                Destroy(gameObject);
            }
        }
    }
}
