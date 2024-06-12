using System;
using DG.Tweening;
using UnityEngine;

namespace LevelScripts.RunnerGame
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Animator playerAnim;
        private bool isDeath;
        private bool isJump;
        private bool levelStart;
        public float speed = 10.0f;
        public GameObject virCamera;

        private void OnEnable()
        {
            BusSystem.OnRunnerLevelStart += LevelStart;
            BusSystem.OnRunnerPlayerJump += Jump;
        }

        private void OnDisable()
        {
            BusSystem.OnRunnerLevelStart -= LevelStart;
            BusSystem.OnRunnerPlayerJump -= Jump;
        }

        private void Start()
        {
            playerAnim.SetTrigger("Idle");
        }

        void Update()
        {
            if (isDeath == false && levelStart)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                virCamera.transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            if (Input.GetMouseButtonDown(0))
            {
               // Jump();
            }
        }

        private void LevelStart()
        {
            playerAnim.SetTrigger("Run");
            levelStart = true;
        }

        private void Jump()
        {
            if (isJump == false && isDeath == false)
            {
                playerAnim.SetTrigger("Jump");
                isJump = true;
              //  transform.DOLocalMoveX(transform.localPosition.x + 3, 0.5f);
                transform.DOLocalMoveY(transform.position.y + 2.5f, 0.5f).OnComplete((() =>
                {
                    transform.DOLocalMoveY(transform.position.y - 2.5f, 0.4f).OnComplete((() =>
                    {
                        isJump = false;
                        if (isDeath == false)
                        {
                            playerAnim.SetTrigger("Run");
                        }
                    }));
                }));
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Obstacle" && isDeath == false)
            {
                BusSystem.CallLevelDone(false);
                playerAnim.SetTrigger("Death");
                isDeath = true;
            }

            if (other.gameObject.tag == "Finish")
            {
                playerAnim.SetTrigger("Dance");
                levelStart = false;
                BusSystem.CallLevelDone(true);
            }
        }
    }
}
