using System;
using UnityEngine;

namespace LevelScripts.RecyleGame
{
    public class ParticleRecyleGame : MonoBehaviour
    {
        [SerializeField] private ParticleSystem partic;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Box")
            {
                partic.Play();
            }
        }
    }
}
