using UnityEngine;
using UnityEngine.EventSystems;

namespace LevelScripts.TankLevel
{
    public class TankButtonController : MonoBehaviour,  IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private int moveType;
        public bool buttonPressed;
 
        public void OnPointerDown(PointerEventData eventData){
            if (moveType>0)
            {
                buttonPressed = true;
                BusSystem.CallTankMove(moveType);
            }
        }
        public void OnPointerUp(PointerEventData eventData){
            if (moveType>0)
            {
                buttonPressed = false;
                BusSystem.CallTankMove(0);
            }
        }
    }
}
