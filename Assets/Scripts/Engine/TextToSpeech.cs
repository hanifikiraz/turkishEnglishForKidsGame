using System;
using System.Collections;
using UnityEngine;

namespace Engine
{
    public class TextToSpeech : MonoBehaviour
    {
        [SerializeField] private AudioSource wordSound;

        private bool isStartSound = true;

        private void Start()
        {
        }

        public void PlaySound()
        {
            if (wordSound != null && isStartSound)
            {
                wordSound.Play();
                StartCoroutine(SetSoundStatus());
            }
        }

        private IEnumerator SetSoundStatus()
        {
            isStartSound = false;
            yield return new WaitForSecondsRealtime(1f);
            isStartSound = true;
        }
    }
}
