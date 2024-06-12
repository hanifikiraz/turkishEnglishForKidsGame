using System;
using UnityEngine;

namespace LevelScripts.MovementLevel
{
    public class MovementPlayerController : MonoBehaviour
    {
        [SerializeField] private Animator playerAnim;
        private bool isDeath;
        private bool isJump;
        
        private void OnEnable()
        {
            BusSystem.OnNewLevelStart += LevelStart;
        }

        private void OnDisable()
        {
            BusSystem.OnNewLevelStart -= LevelStart;
        }

        private void Start()
        {
            playerAnim.SetTrigger("Idle");
        }
        
        private void LevelStart()
        {
            playerAnim.SetTrigger("Run");
        }
        

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Obstacle" && isDeath == false)
            {
                isDeath = true;
                BusSystem.CallLevelDone(false);
                playerAnim.SetTrigger("Death");
                isDeath = true;
            }

            if (other.gameObject.tag == "Finish")
            {
                playerAnim.SetTrigger("Dance");
                BusSystem.CallLevelDone(true);
            }
        }
    }
}
