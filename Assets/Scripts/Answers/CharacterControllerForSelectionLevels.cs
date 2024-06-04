using UnityEngine;

namespace Answers
{
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
               playerAnimator.SetTrigger("Sad");
               break;
            case 3:
               int rndDance = Random.Range(0, 3);
               switch (rndDance)
               {
                  case 0:
                     playerAnimator.SetTrigger("Dance");
                     break;
                  case 1:
                     playerAnimator.SetTrigger("DanceTwo");
                     break;
                  case 2:
                     playerAnimator.SetTrigger("DanceThree");
                     break;
               }
               
               break;
         }
      }
   
   }
}
