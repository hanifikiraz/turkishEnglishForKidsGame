using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelScripts.RecyleGame
{
    public class PlayerRecyleController : MonoBehaviour
    {
        [SerializeField] private GameObject boxPos;
        [SerializeField] private GameObject boxParent;
        [SerializeField] private List<GameObject> endBoxes;
        [SerializeField] private int endCount; 
        private GameObject currentBox;
        private bool isTriggerArea;
        private int currentEndValue = 0;
        

        private IEnumerator SetTriggerArea()
        {
            isTriggerArea = true;
            yield return new WaitForSecondsRealtime(1f);
            isTriggerArea = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "GoArea1" && isTriggerArea == false)
            {
                if (other.gameObject.GetComponent<StandsController>().boxes.Count>=1)
                {
                    StartCoroutine(SetTriggerArea());
                    currentBox = other.gameObject.GetComponent<StandsController>().boxes[0];
                    currentBox.transform.position =
                        boxPos.transform.position;

                    currentBox.transform.rotation =
                        boxPos.transform.rotation;

                    currentBox.transform.SetParent(boxPos.transform);
                    other.gameObject.GetComponent<StandsController>().boxes.Remove(currentBox);
                    BusSystem.CallGoAreValue(1);
                }
            }

            if (other.gameObject.tag == "GoArea2" && isTriggerArea == false)
            {
                StartCoroutine(SetTriggerArea());
                currentBox.transform.SetParent(boxParent.transform);
                currentBox.GetComponent<BoxController>().GoBoxTween();
                BusSystem.CallGoAreValue(5);
            }

            if (other.gameObject.tag == "GoArea3" && isTriggerArea == false)
            {
                StartCoroutine(SetTriggerArea());
                currentBox.transform.position =
                    boxPos.transform.position;

                currentBox.transform.rotation =
                    boxPos.transform.rotation;

                currentBox.transform.SetParent(boxPos.transform);
                BusSystem.CallGoAreValue(3);
            }

            if (other.gameObject.tag == "GoArea4" && isTriggerArea == false)
            {
                foreach (var VARIABLE in endBoxes)
                {
                    if (VARIABLE.GetComponent<EndBoxController>().isFull == false)
                    {
                        VARIABLE.GetComponent<EndBoxController>().isFull = true;
                        currentBox.transform.position = VARIABLE.gameObject.transform.position;
                        currentBox.transform.rotation = VARIABLE.gameObject.transform.rotation;
                        currentBox.transform.SetParent(boxParent.transform);
                        currentBox = null;
                        currentEndValue++;
                        if (currentEndValue==endCount)
                        {
                            Debug.Log("LevelBitti");
                            BusSystem.CallGoAreValue(5);
                            BusSystem.CallRecyleLevelEnd();
                        }
                        else
                        {
                            BusSystem.CallGoAreValue(0);
                        }
                        break; // Döngüden çık
                    }
                }

                StartCoroutine(SetTriggerArea());
            }
        }
    }
}
