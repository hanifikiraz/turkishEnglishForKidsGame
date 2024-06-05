using System;
using UnityEngine;

namespace Unit.UnitController
{
    public class ClassEnabledController : MonoBehaviour
    {
        private void OnEnable()
        {
            BusSystem.CallUnitEnabled();
        }

        private void OnDisable()
        {
            
        }
    }
}
