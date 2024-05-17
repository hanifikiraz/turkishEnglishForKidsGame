using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.ClassMenuController
{
    public class ClassMenuControllerTwoClass : MonoBehaviour
    {
       public enum UnitType
       {
           Words,
           Friends,
           ClassRoom,
           Numbers,
           Colours,
           Playground,
           BodyParts,
           Pets,
           Fruit,
           Animals
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
               case UnitType.Words:
                   SpriteSelection(0);
                   break;
               case UnitType.Friends:
                   SpriteSelection(1);
                   break;
               case UnitType.ClassRoom:
                   SpriteSelection(2);
                   break;
               case UnitType.Numbers:
                   SpriteSelection(3);
                   break;
               case UnitType.Colours:
                   SpriteSelection(4);
                   break;
               case UnitType.Playground:
                   SpriteSelection(5);
                   break;
               case UnitType.BodyParts:
                   SpriteSelection(6);
                   break;
               case UnitType.Pets:
                   SpriteSelection(7);
                   break;
               case UnitType.Fruit:
                   SpriteSelection(8);
                   break;
               case UnitType.Animals:
                   SpriteSelection(9);
                   break;
           }
       }
    }
}
