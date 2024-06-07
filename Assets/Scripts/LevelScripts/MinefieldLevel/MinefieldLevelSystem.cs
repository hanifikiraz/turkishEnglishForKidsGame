using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace LevelScripts.MinefieldLevel
{
    public class MinefieldLevelSystem : MonoBehaviour
    {
        [SerializeField] private List<GameObject> buttons;
        [SerializeField] private List<GameObject> hearts;
        [SerializeField] private GameObject levelLoseUI;
        [SerializeField] private GameObject levelWinUI;
        [SerializeField] private GameObject particlesForWin;
        [SerializeField] private List<ParticleSystem> particles;
        [SerializeField] private int mainerValue;
        private bool isClick = false;
        private int heartValue = 3;

        private void RotateButtons(float value)
        {
            foreach (var VARIABLE in buttons)
            {
                VARIABLE.transform.DOLocalRotate(new Vector3(0,value,0),0.5f);
            }
            
        }

        private IEnumerator StartRotateObjectController()
        {
            yield return new WaitForSecondsRealtime(1f);
            RotateButtons(180);
            yield return new WaitForSecondsRealtime(4f);
            RotateButtons(0);
            isClick = true;
        }
        private void Start()
        {
            StartCoroutine(StartRotateObjectController());
        }

        void Update()
        {
            // Mouse sol tıklama işlemi kontrol ediliyor.
            if (Input.GetMouseButtonDown(0))
            {
                // Tıklanan noktanın ekran koordinatları alınıyor.
                Vector3 mousePosition = Input.mousePosition;
                // Ekran koordinatlarından ışın oluşturuluyor.
                Ray ray = Camera.main.ScreenPointToRay(mousePosition);
                RaycastHit hit;

                // Işın, bir objeyle temas etti mi diye kontrol ediliyor.
                if (Physics.Raycast(ray, out hit))
                {
                    // Eğer temas edilen obje varsa, objenin adı yazdırılıyor.
                    Debug.Log("Tıklanan obje adı: " + hit.transform.name);
                    if (hit.transform.gameObject.name == "MinefieldObject" && isClick)
                    {
                        isClick = false;
                            hit.transform.parent.transform.DOLocalRotate(new Vector3(0,180,0),0.5f).OnComplete((
                                    () =>
                                    {
                                        if (hit.transform.parent.GetComponent<MineFieldObject>().ObjectID == 1)
                                        {
                                            BusSystem.CallPlayerSetAnim(3);
                                            mainerValue--;
                                            hit.transform.parent.DOScale(Vector3.zero, 1f).SetDelay(0.5f).OnComplete((
                                                () =>
                                                {
                                                    isClick = true;
                                                }));
                                            if (mainerValue==0)
                                            {
                                                levelWinUI.SetActive(true);
                                                particlesForWin.SetActive(true);
                                                foreach (var VARIABLE in particles)
                                                {
                                                    VARIABLE.Play();
                                                }
                                                levelWinUI.transform.DOScale(Vector3.zero,0.7f).From().OnComplete((() =>
                                                {
                                                    BusSystem.CallLevelWinStatusForCanvas(true);
                                                }));
                                                
                                            }
                                        }
                                        else
                                        {
                                            heartValue--;
                                            BusSystem.CallPlayerSetAnim(2);
                                            foreach (var VARIABLE in hearts)
                                            {
                                                VARIABLE.SetActive(false);
                                            }

                                            for (int i = 0; i < heartValue; i++)
                                            {
                                                hearts[i].SetActive(true);
                                                isClick = true;
                                            }

                                            if (heartValue==0)
                                            {
                                                levelLoseUI.SetActive(true);
                                                levelLoseUI.transform.DOScale(Vector3.zero,0.7f).From().OnComplete((
                                                    () =>
                                                    {
                                                        BusSystem.CallLevelWinStatusForCanvas(false);
                                                    }));
                                            }
                                        }
                                    }));
                        }
                    }
                }
            }
        }
    }

