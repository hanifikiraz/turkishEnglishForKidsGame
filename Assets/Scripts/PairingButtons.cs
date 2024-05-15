using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PairingButtons : MonoBehaviour
{
    [SerializeField] private string objectName;
    [SerializeField] private TextMeshProUGUI objectText;
    public int objectID;

    private void Start()
    {
        objectText.text = objectName;
    }

    public void SetTypePairing()
    {
        BusSystem.CallPairingButtons(gameObject.GetComponent<PairingButtons>());
    }
    
}
