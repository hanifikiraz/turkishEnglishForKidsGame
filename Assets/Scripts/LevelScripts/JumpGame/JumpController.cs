using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class JumpController : MonoBehaviour
{
   [SerializeField] private GameObject floatingImage;
   [SerializeField] private GameObject particle;
   [SerializeField] private List<ParticleSystem> particles;
   [SerializeField] private List<GameObject> closedUI;
   [SerializeField] private TextMeshProUGUI levelDoneText;
   [SerializeField] private float maxX;
   [SerializeField] private float minX;
   [SerializeField] private float maxXBar;
   [SerializeField] private float minXBar;
   private Tween fillTween;

   private void OnEnable()
   {
      BusSystem.OnJumpLevelDone += JumpLevelDone;
   }

   private void OnDisable()
   {
      BusSystem.OnJumpLevelDone -= JumpLevelDone;
   }
   
   private void Start()
   {
      levelDoneText.gameObject.SetActive(false);
      FloatingTweenMaxX();
   }

   private void JumpLevelDone()
   {
      particle.SetActive(true);
      levelDoneText.gameObject.SetActive(true);
      foreach (var VARIABLE in closedUI)
      {
         VARIABLE.SetActive(false);
      }
      foreach (var VARIABLE in particles)
      {
         VARIABLE.Play();
      }
      levelDoneText.gameObject.transform.localScale = Vector3.zero;
      levelDoneText.gameObject.transform.DOScale(Vector3.one, 0.7f);
   }

   public void JumpControl()
   {
      if (floatingImage.transform.localPosition.x>=minX && floatingImage.transform.localPosition.x<= maxX)
      {
         Debug.Log("KAZANDI");
         BusSystem.CallPlayerJump();
      }
   }

   private void FloatingTweenMaxX()
   {
      floatingImage.transform.DOLocalMoveX(maxXBar,1f).OnComplete(FloatingTweenMinX);
   }
   private void FloatingTweenMinX()
   {
      floatingImage.transform.DOLocalMoveX(minXBar,1f).OnComplete(FloatingTweenMaxX);
   }

}
