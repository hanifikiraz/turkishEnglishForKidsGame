using System;
using UnityEngine;

namespace LevelScripts.AAGameLevel
{
    public class ArrowController : MonoBehaviour
    {
        private bool isTrigSphere;
        private void Update()
        {
            if (isTrigSphere == false)
            {
                transform.Translate(0,10*Time.deltaTime,0);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "RotatingObject")
            {
                isTrigSphere = true;
                gameObject.transform.parent = other.gameObject.transform;
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
               // BusSystem.CallPlayerSetAnim(2);
                
            }

            if (other.gameObject.tag == "Arrow")
            {
                BusSystem.CallAAGameLevelEnd();
                Debug.Log("AAAAAAAAAAAA");
            }
        }
    }
}
