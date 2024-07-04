using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.ClassMenuController
{
    public class ClassMenuControllerFourClass : MonoBehaviour
    {
        public enum UnitType
        {
            ClassRules,
            Nationality,
            Cartoon,
            FreeTime,
            MyDay,
            Science,
            Jobs,
            Clothes,
            Friends,
            Food
             
        }
        public GameObject LockGameObject;
        [SerializeField] private UnitType unitType;
        [SerializeField] private List<Sprite> unitImages;
        [SerializeField] private Image defaultImage;
        [SerializeField] private TextMeshProUGUI unitText;
        [SerializeField] private TextMeshProUGUI lockText;
        [SerializeField] private string unitTextString;
        [SerializeField] private GameObject myCanvas;
        [SerializeField] private GameObject unitCanvas;
    
        private void OnValidate()
        {
            UnitSelection();
            unitText.text = unitTextString;
            lockText.text = unitTextString;
        }
        public void OpenUnit()
        {
            if (LockGameObject.activeSelf == false)
            {
                unitCanvas.SetActive(true);
                myCanvas.SetActive(false);
            }
        }
    
        private void SpriteSelection(int value)
        {
            defaultImage.sprite = unitImages[value];
        }
        private void UnitSelection()
        {
            switch (unitType)
            {
                case UnitType.ClassRules:
                    SpriteSelection(0);
                    break;
                case UnitType.Nationality:
                    SpriteSelection(1);
                    break;
                case UnitType.Cartoon:
                    SpriteSelection(2);
                    break;
                case UnitType.FreeTime:
                    SpriteSelection(3);
                    break;
                case UnitType.MyDay:
                    SpriteSelection(4);
                    break;
                case UnitType.Science:
                    SpriteSelection(5);
                    break;
                case UnitType.Jobs:
                    SpriteSelection(6);
                    break;
                case UnitType.Clothes:
                    SpriteSelection(7);
                    break;
                case UnitType.Friends:
                    SpriteSelection(8);
                    break;
                case UnitType.Food:
                    SpriteSelection(9);
                    break;
            }
        }
    }
}
