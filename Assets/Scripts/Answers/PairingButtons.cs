using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Answers
{
    public class PairingButtons : MonoBehaviour
    {
        [SerializeField] private Image defaultImage;
        [SerializeField] private Sprite clickImage;
        [SerializeField] private Sprite wrongImage;
        [SerializeField] private Sprite correctImage;
        [SerializeField] private Sprite defaultSprite;
        [SerializeField] private string objectName;
        [SerializeField] private TextMeshProUGUI objectText;
        public int ID;

        private void Start()
        {
            //objectText.text = objectName;
        }

        public void SetTypePairing()
        {
            SetImage(1);
            BusSystem.CallPairingButtons(gameObject.GetComponent<PairingButtons>());
        }

        public void SetImage(int value)
        {
            switch (value)
            {
                case 0:
                    defaultImage.sprite = defaultSprite;
                    break;
                case 1:
                    defaultImage.sprite = clickImage;
                    break;
                case 2:
                    defaultImage.sprite = wrongImage;
                    break;
                case 3:
                    defaultImage.sprite = correctImage;
                    break;
            
            }
        }

    }
}
