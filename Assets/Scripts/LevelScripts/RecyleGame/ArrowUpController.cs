using System;
using DG.Tweening;
using UnityEngine;

namespace LevelScripts.RecyleGame
{
    public class ArrowUpController : MonoBehaviour
    {
        [SerializeField] private GameObject arrow;
        [SerializeField] private float startPos;
        [SerializeField] private float endPos;
        [SerializeField] private float duration;
        private Tween upTween;

        private void OnEnable()
        {
            UpTweenArrow();
        }

        private void OnDisable()
        {
            upTween.Kill();
        }

        private void UpTweenArrow()
        {
            upTween = arrow.transform.DOLocalMoveY(endPos, duration).OnComplete(DownTweenArrow);
        }
        private void DownTweenArrow()
        {
            upTween = arrow.transform.DOLocalMoveY(startPos, duration).OnComplete(UpTweenArrow);
        }

    }
}
