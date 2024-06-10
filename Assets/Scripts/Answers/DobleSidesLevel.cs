using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Answers
{
    public class DobleSidesLevel : MonoBehaviour
    {
        [SerializeField] private List<GameObject> buttons;
        [SerializeField] private GameObject particlesForWin;
        [SerializeField] private GameObject buttonsBackGround;
        [SerializeField] private GameObject congText;
        [SerializeField] private List<ParticleSystem> partic;
        [SerializeField] private List<DoubleSideObject> doubleSidesObject;
    
        private void SetDoubleSidesButtons(DoubleSideObject buttonsObject)
        {
            doubleSidesObject.Add(buttonsObject);
        
            if (doubleSidesObject.Count>=2)
            {
                if (doubleSidesObject[0].GetComponent<DoubleSideObject>().objectID == doubleSidesObject[1].GetComponent<DoubleSideObject>().objectID )
                {
                    Debug.Log("TRUE");
                    BusSystem.CallPlayerSetAnim(3);
                    StartCoroutine(CollectObject());
                }
                else
                {
                    Debug.Log("FALSE");
                
                    BusSystem.CallPlayerSetAnim(2);
                    StartCoroutine(RotateDefault());
                

                }
            
            }   
        }

        private IEnumerator CollectObject()
        {
            yield return new WaitForSecondsRealtime(0.4f);
            foreach (var VARIABLE in doubleSidesObject)
            {
                VARIABLE.transform.DOScale(Vector3.zero, 0.8f).OnComplete(LevelEndController);
            }
            doubleSidesObject.Clear();
        }

        private IEnumerator RotateDefault()
        {
            yield return new WaitForSecondsRealtime(0.5f);
            foreach (var VARIABLE in buttons)
            {
                VARIABLE.transform.DOLocalRotate(Vector3.zero, 0.5f);
            }
            doubleSidesObject.Clear();
        }
        private void LevelEndController()
        {
            int value = 0;
            foreach (var VARIABLE in buttons)
            {
                if (VARIABLE.transform.localScale.z == 0)
                {
                    value++;
                }
            }

            if (value == buttons.Count)
            {
                Debug.Log("LEVEL ENDD  " + value);
                StartCoroutine(LevelEndAnim());
            }
        }
        private IEnumerator LevelEndAnim()
        {
            buttonsBackGround.transform.DOMoveY(-5, 1f);
            yield return new WaitForSecondsRealtime(0.4f);
            particlesForWin.SetActive(true);
            congText.SetActive(true);
            congText.gameObject.transform.DOScale(Vector3.zero, 0.7f).From().OnComplete((() =>
            {
                BusSystem.CallLevelWinStatusForCanvas(true);
            }));
            foreach (var VARIABLE in partic)
            {
                VARIABLE.Play();
            }
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
                    if (doubleSidesObject.Count<2)
                    {
                        if (hit.transform.gameObject.name == "DoubleSideObject")
                        {
                            SetDoubleSidesButtons(hit.transform.parent.transform.gameObject.GetComponent<DoubleSideObject>());
                            hit.transform.parent.transform.DOLocalRotate(new Vector3(0,180,0),0.5f);
                        }
                    }
                }
            }
        }
    }
}
