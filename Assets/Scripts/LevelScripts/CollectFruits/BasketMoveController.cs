using UnityEngine;
using UnityEngine.EventSystems;

namespace LevelScripts.CollectFruits
{
    public class BasketMoveController : MonoBehaviour,  IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private int moveType;
        public bool buttonPressed;
 
        public void OnPointerDown(PointerEventData eventData){
            if (moveType>0)
            {
                buttonPressed = true;
                BusSystem.CallBasketMove(moveType);
            }
       
        }
        public void OnPointerUp(PointerEventData eventData){
            if (moveType>0)
            {
                buttonPressed = false;
                BusSystem.CallBasketMove(0);
            }
      
        }
    }
}
