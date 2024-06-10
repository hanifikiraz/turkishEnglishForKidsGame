using System;
using UnityEngine;

namespace Answers
{
    public class DoubleSideObject : MonoBehaviour
    {
        public int objectID;
        [SerializeField] private Material objectMaterial;
        [SerializeField] private GameObject materialObject;

        private void OnValidate()
        {
            gameObject.name = objectMaterial.name;
            materialObject.GetComponent<MeshRenderer>().material = objectMaterial;
        }
    }
}
