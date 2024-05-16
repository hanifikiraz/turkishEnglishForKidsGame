using System;
using System.Collections.Generic;
using UnityEngine;

namespace LevelScripts.MinefieldLevel
{
    public class MineFieldObject : MonoBehaviour
    {
        public enum VariableType
        {
            Red,
            Blue,
            Yellow,
            Green
        }

        [SerializeField] private List<Material> materials;
        [SerializeField] private GameObject objectMaterial;
        [SerializeField] private VariableType varType;
        public int ObjectID;

        private void Start()
        {
            ChangeMaterial();
        }

        private void ChangeMaterial()
        {
            
            switch (varType)
            {
                case VariableType.Red:
                    objectMaterial.GetComponent<Renderer>().material = materials[0];
                   break; 
                case VariableType.Blue:
                    objectMaterial.GetComponent<Renderer>().material = materials[1];
                    break; 
                case VariableType.Yellow:
                    objectMaterial.GetComponent<Renderer>().material = materials[2];
                    break; 
                case VariableType.Green:
                    objectMaterial.GetComponent<Renderer>().material = materials[3];
                    break; 
                
            }
        }
    }
}
