using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LevelScripts.LetterGame
{
    public class LetterSelection : MonoBehaviour
    {
        public enum LetterType
        {
            Transparent,
            NoTransparent
        }

        public enum Letters
        {
            A,B,C,D,E,F,G,H,J,K,I,L,M,N,O,P,R,S,T,Y,Z,U,V,W,Q,X
        }

        public LetterType letterType;
        public Letters letters;
        public bool isTaked;
        public bool isCompleted;
        
        [SerializeField] private List<Material> materials;
        [SerializeField] private Material transparentMaterial;

        private void OnValidate()
        {
            if (letterType == LetterType.NoTransparent)
            {
                SetMaterial(1);
            }
            else
            {
                SetMaterial(2);
            }
            
        }

        private void SetMaterial(int value)
        {
            if (value == 1)
            {
                int randomMaterial = Random.Range(0, materials.Count);
                gameObject.GetComponent<MeshRenderer>().material = materials[randomMaterial];
            }
            else
            {
                gameObject.GetComponent<MeshRenderer>().material = transparentMaterial;
            }
            
        }


    }
}
