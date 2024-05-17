using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.ClassMenuController
{
    public class ClassMenuControllerThreeClass : MonoBehaviour
    {
        public enum UnitType
        {
            Greetings,
            Family,
            People,
            Feelings,
            Toys,
            MyHouse,
            MyCity,
            Transportation,
            Weather,
            Nature
            
        }
          
        [SerializeField] private UnitType unitType;
        [SerializeField] private List<Sprite> unitImages;
        [SerializeField] private Image defaultImage;
        [SerializeField] private TextMeshProUGUI unitText;
        [SerializeField] private string unitTextString;
   
        private void OnValidate()
        {
            UnitSelection();
            unitText.text = unitTextString;
        }
   
        private void SpriteSelection(int value)
        {
            defaultImage.sprite = unitImages[value];
        }
        private void UnitSelection()
        {
            switch (unitType)
            {
                case UnitType.Greetings:
                    SpriteSelection(0);
                    break;
                case UnitType.Family:
                    SpriteSelection(1);
                    break;
                case UnitType.People:
                    SpriteSelection(2);
                    break;
                case UnitType.Feelings:
                    SpriteSelection(3);
                    break;
                case UnitType.Toys:
                    SpriteSelection(4);
                    break;
                case UnitType.MyHouse:
                    SpriteSelection(5);
                    break;
                case UnitType.MyCity:
                    SpriteSelection(6);
                    break;
                case UnitType.Transportation:
                    SpriteSelection(7);
                    break;
                case UnitType.Weather:
                    SpriteSelection(8);
                    break;
                case UnitType.Nature:
                    SpriteSelection(9);
                    break;
            }
        }
    }
}
