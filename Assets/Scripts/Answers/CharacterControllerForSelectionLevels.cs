using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerForSelectionLevels : MonoBehaviour
{
   [SerializeField] private GameObject player;
   [SerializeField] private Animator playerAnimator;
   private int setAnim;
   

   private void OnEnable()
   {
      BusSystem.OnPlayerSetAnim += SetAnim;
   }

   private void OnDisable()
   {
      BusSystem.OnPlayerSetAnim -= SetAnim;
   }

   private void SetAnim(int value)
   {
      switch (value)
      {
         case 1:
            playerAnimator.SetTrigger("Idle");
            break;
         case 2:
            playerAnimator.SetTrigger("Happy");
            break;
         case 3:
            playerAnimator.SetTrigger("Sad");
            break;
      }
   }
   
}
