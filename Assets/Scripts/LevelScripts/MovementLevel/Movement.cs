using System;
using UnityEngine;

namespace LevelScripts.MovementLevel
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float sensitivityTouch = 0.1f;
        [SerializeField] private float swipeSpeed;
        [SerializeField] private float maxX;
        [SerializeField] private float minX;
        [SerializeField] private GameObject cam;
        private Vector2 touchStartPos;
        private Vector3 targetPosition;
        private bool isMoving = false;
        private bool playMove;

        private void OnEnable()
        {
            BusSystem.OnNewLevelStart += LevelStart;
            BusSystem.OnLevelDone += LevelDone;
        }

        private void OnDisable()
        {
            BusSystem.OnNewLevelStart -= LevelStart;
            BusSystem.OnLevelDone -= LevelDone;
        }

        private void LevelStart()
        {
            playMove = true;
        }
        private void LevelDone(bool value)
        {
            playMove = false;
        }

        private void Update()
        {
            if (playMove)
            {
                MoveFor();
            }
        }
        private void MoveFor()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    touchStartPos = touch.position;
                    targetPosition = transform.position;
                    isMoving = true;
                }
                else if (touch.phase == TouchPhase.Moved && isMoving)
                {
                    Vector2 lastTouch = touch.position;
                    Vector2 touchDirection = lastTouch - touchStartPos;

                    float movementAmount = touchDirection.x * sensitivityTouch;
                    targetPosition.x += movementAmount;
                    targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);

                    touchStartPos = lastTouch;
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    isMoving = false;
                }
               
            }

           
            if (isMoving)
            {
                var trnsform = transform.position = new Vector3(targetPosition.x,targetPosition.y,transform.position.z);
                transform.position = Vector3.Lerp(transform.position, trnsform, Time.deltaTime * 10f);
                
            }
            transform.position = new Vector3(transform.position.x, transform.position.y,
                transform.position.z + moveSpeed * Time.deltaTime);
                cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y,
                    cam.transform.position.z + moveSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Finish")
            {
                BusSystem.CallLevelDone(true);
            }
        }
    }
}
