using System;
using UnityEngine;

namespace LevelScripts.AAAAAOthers
{
    public class DestroyObject : MonoBehaviour
    {
        private void OnEnable()
        {
            Destroy(gameObject,3f);
        }
    }
}
