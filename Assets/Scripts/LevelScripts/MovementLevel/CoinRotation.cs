using System;
using UnityEngine;

namespace LevelScripts.MovementLevel
{
    public class CoinRotation : MonoBehaviour
    {
        [SerializeField] private float roationSpeed;
        [SerializeField] private ParticleSystem partic;
        [SerializeField] private AudioSource coinSound;
        private void Update()
        {
            transform.Rotate(Vector3.up * roationSpeed * Time.deltaTime );
        }

        private void InstantiateCoinAndPartic()
        {
            ParticleSystem insPartic = Instantiate(partic, gameObject.transform.position, Quaternion.identity);
            partic.Play();
            AudioSource insAudio = Instantiate(coinSound, gameObject.transform.position, Quaternion.identity);
            insAudio.Play();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                InstantiateCoinAndPartic();
                Destroy(gameObject);
            }
        }
    }
}
