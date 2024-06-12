using System;
using Joystick_Pack.Scripts.Joysticks;
using UnityEngine;

namespace LevelScripts.LetterGame
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private FloatingJoystick _joystick;
        [SerializeField] private Animator animator;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private Transform letterPosition;

        private Rigidbody _rigidbody;

        private Vector3 _moveVector;

        private GameObject letter;


        public bool isMove;
        private bool playerMovedRedLight;
        //private bool canMove;
        private bool isTakeLetter;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();


        }

        private void Start()
        {
            animator.SetTrigger("Idle");
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
           
                // gameObject.GetComponent<BoxCollider>().isTrigger = false;
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
                {
                 //   canMove = true;
                }
                Move();  
            }

            if (Input.GetMouseButtonDown(0))
            {

                animator.SetTrigger("Run");
            }

            if (Input.GetMouseButtonUp(0))
            {
               // gameObject.GetComponent<BoxCollider>().isTrigger = true;
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
              //  canMove = false;

                animator.SetTrigger("Idle");
            }
        }

        private void Move()
        {
            _moveVector = Vector3.zero;
            _moveVector.x = _joystick.Horizontal * _moveSpeed * Time.deltaTime;
            _moveVector.z = _joystick.Vertical * _moveSpeed * Time.deltaTime;
            if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
            {
              //  canMove = true;
                Vector3 direction =
                    Vector3.RotateTowards(transform.forward, _moveVector, _rotateSpeed * Time.deltaTime, 0.0f);
                transform.rotation = Quaternion.LookRotation(direction);
                if (isMove == false)
                {
                    if (playerMovedRedLight == false)
                    {
                        playerMovedRedLight = true;
                    }
                }


                // animator.SetTrigger("Run");
            }

            else if (_joystick.Horizontal == 0 && _joystick.Vertical == 0)
            {

            }

            _rigidbody.MovePosition(_rigidbody.position + _moveVector);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Letter")
            {
                if (other.gameObject.GetComponent<LetterSelection>().letterType == LetterSelection.LetterType.NoTransparent && isTakeLetter == false )
                {
                    if (other.gameObject.GetComponent<LetterSelection>().isTaked == false)
                    {
                        BusSystem.CallFruitSound();
                        letter = other.gameObject;
                        Debug.Log("AAAAAAAAAAAAAAA "+ other.gameObject.name);
                        letter.transform.SetParent(null);
                        letter.transform.position = letterPosition.position;
                        letter.transform.rotation = letterPosition.rotation;
                        letter.transform.parent = letterPosition.transform;
                        isTakeLetter = true;
                    }
                }

                if (other.gameObject.GetComponent<LetterSelection>().letterType == LetterSelection.LetterType.Transparent && isTakeLetter)
                {
                    if (letter.GetComponent<LetterSelection>().letters == other.gameObject.GetComponent<LetterSelection>().letters)
                    {
                        BusSystem.CallFruitSound();
                        isTakeLetter = false;
                        letter.transform.position = other.gameObject.transform.position;
                        letter.transform.rotation = other.gameObject.transform.rotation;
                        other.gameObject.GetComponent<MeshRenderer>().material =
                            letter.GetComponent<MeshRenderer>().material;
                        other.gameObject.GetComponent<BoxCollider>().enabled = false;
                        other.gameObject.GetComponent<MeshRenderer>().enabled = false;
                        other.gameObject.GetComponent<LetterSelection>().isCompleted = true;
                        letter.GetComponent<LetterSelection>().isTaked = true;
                        letter.transform.parent = other.gameObject.transform.parent;
                        letter = null;
                        BusSystem.CallFruitSound();
                        BusSystem.CallMaterialControlLetter();
                    }
                }
            }
        }
    }
}
        
    

