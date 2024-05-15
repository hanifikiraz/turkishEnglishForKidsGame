using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PairingLevelSystem : MonoBehaviour
{

    [SerializeField] private List<PairingButtons> pairingButtons;

    private void OnEnable()
    {
        BusSystem.OnPairingButtons += SetPairingButtons;
    }

    private void OnDisable()
    {
        BusSystem.OnPairingButtons -= SetPairingButtons;
    }

    private void SetPairingButtons(PairingButtons buttons)
    {
        pairingButtons.Add(buttons);
        
        if (pairingButtons.Count>=2)
        {
            if (pairingButtons[0].GetComponent<PairingButtons>().objectID == pairingButtons[1].GetComponent<PairingButtons>().objectID )
            {
                Debug.Log("TRUE");
                foreach (var VARIABLE in pairingButtons)
                {
                    VARIABLE.transform.DOScale(Vector3.zero, 0.3f);
                }
            }
            else
            {
                Debug.Log("FALSE");
            }
            pairingButtons.Clear();
        }   
    }
}
