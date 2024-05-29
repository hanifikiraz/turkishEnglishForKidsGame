using System;
using UnityEngine;

namespace Engine
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource mainMenuSound;
        [SerializeField] private AudioSource levelSound1;
        [SerializeField] private AudioSource levelSound2;
        [SerializeField] private AudioSource levelSound3;
        [SerializeField] private AudioSource buttonSound;
        [SerializeField] private AudioSource levelWinSound;
        [SerializeField] private AudioSource levelLoseSound;
        [SerializeField] private AudioSource levelPairingWonSound;
        [SerializeField] private AudioSource levelPairingLoseSound;

        private void OnEnable()
        {
            BusSystem.OnAudioChange += MusicSelection;
        }

        private void OnDisable()
        {
            BusSystem.OnAudioChange -= MusicSelection;
        }

        private void MusicSelection(int value)
        {
            switch (value)
            {
               case 1:
                   MainMenuSound();
                   break;
               case 2:
                   LevelSound1();
                   break;
               case 3:
                   LevelSound2();
                   break;
               case 4:
                   LevelSound3();
                   break;
               case 5:
                   ButtonSound();
                   break;
               case 6:
                   LevelWinSound();
                   break;
               case 7:
                   LevelLoseSound();
                   break;
               case 8:
                   LevelPairingWonSound();
                   break;
               case 9:
                   LevelPairingLoseSound();
                   break;
               case 10:
                   AllMusicStop();
                   break;
            }
        }

        private void MainMenuSound()
        {
            mainMenuSound.Stop();
            mainMenuSound.Play();
        }
        private void LevelSound1()
        {
            levelSound1.Stop();
            levelSound1.Play();
        }
        private void LevelSound2()
        {
            levelSound2.Stop();
            levelSound2.Play();
        }
        private void LevelSound3()
        {
            levelSound3.Stop();
            levelSound3.Play();
        }
        private void ButtonSound()
        {
            buttonSound.Stop();
            buttonSound.Play();
        }
        private void LevelWinSound()
        {
            levelWinSound.Stop();
            levelWinSound.Play();
        }
        private void LevelLoseSound()
        {
            levelLoseSound.Stop();
            levelLoseSound.Play();
        }
        private void LevelPairingWonSound()
        {
            levelPairingWonSound.Stop();
            levelPairingWonSound.Play();
        }
        private void LevelPairingLoseSound()
        {
            levelPairingLoseSound.Stop();
            levelPairingLoseSound.Play();
        }

        private void AllMusicStop()
        { 
            mainMenuSound.Stop();
            levelSound1.Stop();
            levelSound2.Stop();
            levelSound3.Stop();
            buttonSound.Stop();
            levelWinSound.Stop();
            levelLoseSound.Stop();
            levelPairingWonSound.Stop();
            levelPairingLoseSound.Stop();
        }
    }
}
