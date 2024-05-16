using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PairingLevelSystem : MonoBehaviour
{

    [SerializeField] private List<GameObject> buttons;
    [SerializeField] private GameObject particlesForWin;
    [SerializeField] private GameObject buttonsBackGround;
    [SerializeField] private GameObject congText;
    [SerializeField] private List<ParticleSystem> partic;
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
                BusSystem.CallPlayerSetAnim(2);
                foreach (var VARIABLE in pairingButtons)
                {
                    VARIABLE.GetComponent<PairingButtons>().SetImage(3);
                    VARIABLE.transform.DOScale(Vector3.zero, 0.5f).OnComplete(LevelEndController);
                }
            }
            else
            {
                foreach (var VARIABLE in pairingButtons)
                {
                    VARIABLE.GetComponent<PairingButtons>().SetImage(2);
                }
                Debug.Log("FALSE");
                BusSystem.CallPlayerSetAnim(3);
              
            }
            pairingButtons.Clear();
            StartCoroutine(SpriteChange());

        }   
    }

    private IEnumerator SpriteChange()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        foreach (var VARIABLE in this.buttons)
        {
            VARIABLE.GetComponent<PairingButtons>().SetImage(0);
        }
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
        congText.gameObject.transform.DOScale(Vector3.zero, 0.7f).From();
        foreach (var VARIABLE in partic)
        {
            VARIABLE.Play();
        }
    }
}
