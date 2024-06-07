using System;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class GameCanvasController : MonoBehaviour
    {
        [SerializeField] private Image areaImage;
        [SerializeField] private Image areaImageTwo;

        private void OnEnable()
        {
            SetImage(false);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
               // SetImage(true);
            }
            if (Input.GetMouseButtonUp(0))
            {
                SetImage(false);
            }
        }

        private void SetImage(bool value)
        {
            areaImage.enabled = value;
            areaImageTwo.enabled = value;
        }
    }
}
