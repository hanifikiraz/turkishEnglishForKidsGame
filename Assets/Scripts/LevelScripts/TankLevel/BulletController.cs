using System;
using DG.Tweening;
using UnityEngine;

namespace LevelScripts.TankLevel
{
    public class BulletController : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float lifeTime;

        private void Start()
        {
            Destroy(gameObject,lifeTime);
        }

        private void Update()
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "MovingParent")
            {
                Destroy(gameObject);
            }
        }
    }
}
