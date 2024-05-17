using System;
using DG.Tweening;
using UnityEngine;

namespace LevelScripts.TankLevel
{
    public class BulletController : MonoBehaviour
    {
        public void GoTarget(Transform pos)
        {
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Finish")
            {
                Destroy(gameObject);
            }
        }
    }
}
