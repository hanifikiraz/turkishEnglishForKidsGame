using System;
using UnityEngine;

namespace Unit.UnitController
{
    public class ContentController : MonoBehaviour
    {
        [SerializeField] private float contentY;

        private void Start()
        {
            SetContentYPos();
        }

        public void SetContentYPos()
        {
            gameObject.transform.position =
                new Vector3(gameObject.transform.position.x, contentY, gameObject.transform.position.z);
        }
    }
}
