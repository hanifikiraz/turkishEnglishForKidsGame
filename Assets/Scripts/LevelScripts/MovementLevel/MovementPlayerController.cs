using UnityEngine;

namespace LevelScripts.MovementLevel
{
    public class MovementPlayerController : MonoBehaviour
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
        }

        private void OnDisable()
        {
            BusSystem.OnRunnerLevelStart -= LevelStart;
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
        }

        private void LevelStart()
        {
            playerAnim.SetTrigger("Run");
            levelStart = true;
        }
        

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Obstacle")
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
