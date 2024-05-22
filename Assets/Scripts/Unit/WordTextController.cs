using System;
using TMPro;
using UnityEngine;

namespace Unit
{
    public class WordTextController : MonoBehaviour
    {
        [SerializeField] private string wordTextStr;
        [SerializeField] private TextMeshProUGUI wordTextMesh;

        private void OnValidate()
        {
            SetText();
        }

        private void SetText()
        {
            wordTextMesh.text = wordTextStr;
        }
    }
}
