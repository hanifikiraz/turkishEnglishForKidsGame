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
        [SerializeField] private float movingDuration;
        public MovingSelection movSelect;

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
            mainObject.transform.DOLocalMove(leftObject.transform.localPosition, movingDuration).OnComplete(SetMoveRight);
        }
        private void SetMoveRight()
        {
            mainObject.transform.DOLocalMove(rightObject.transform.localPosition, movingDuration).OnComplete(SetMoveLeft);
        }
    }
}
