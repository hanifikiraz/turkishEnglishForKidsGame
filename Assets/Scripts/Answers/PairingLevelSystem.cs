using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Answers
{
    public class PairingLevelSystem : MonoBehaviour
    {
        [SerializeField] private List<string> objectEnglishName;
        [SerializeField] private List<string> objectTurkishName;
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
    void Start()
    {
        BusSystem.CallAudioChange(10);
        BusSystem.CallAudioChange(4);
        // 4 English and 4 Turkish words randomly selected from the full list
        List<string> selectedEnglish = GetUniqueRandomButtons(objectEnglishName, 4);
        List<string> selectedTurkish = new List<string>();

        

        foreach (string englishWord in selectedEnglish)
        {
            int index = objectEnglishName.IndexOf(englishWord);
            selectedTurkish.Add(objectTurkishName[index]);
            Debug.Log(englishWord);
        }

        // Combine the selected English and Turkish words
        List<string> combinedTexts = new List<string>(selectedEnglish);
        combinedTexts.AddRange(selectedTurkish);

        // Shuffle the combined list of texts
        FisherYatesShuffle(combinedTexts);

        // Assign texts to buttons and set IDs
        for (int i = 0; i < buttons.Count; i++)
        {
            SetButtonText(buttons[i], combinedTexts[i]);

            string buttonText = combinedTexts[i];
            int englishIndex = objectEnglishName.IndexOf(buttonText);
            int turkishIndex = objectTurkishName.IndexOf(buttonText);

            if (englishIndex != -1)
            {
                buttons[i].GetComponent<PairingButtons>().ID = englishIndex + 1;
            }
            else if (turkishIndex != -1)
            {
                buttons[i].GetComponent<PairingButtons>().ID = turkishIndex + 1;
            }
            else
            {
                Debug.LogError("Matching index not found for button text: " + buttonText);
            }
        }
    }

    List<string> GetUniqueRandomButtons(List<string> list, int count)
    {
        List<string> selectedButtons = new List<string>();
        List<string> possibleButtons = new List<string>(list);

        // Ensure there are enough buttons to select from
        if (possibleButtons.Count < count)
        {
            Debug.LogError("Not enough buttons to select from.");
            return selectedButtons;
        }

        // Shuffle the possible buttons and take the first 'count' buttons
        for (int i = 0; i < count; i++)
        {
            int randomIndex = Random.Range(0, possibleButtons.Count);
            string selectedButton = possibleButtons[randomIndex];
            possibleButtons.RemoveAt(randomIndex);
            selectedButtons.Add(selectedButton);
        }

        return selectedButtons;
    }

    void SetButtonText(GameObject button, string text)
    {
        TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
        if (buttonText != null)
        {
            buttonText.text = text;
        }
    }

    void FisherYatesShuffle<T>(List<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            T temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
        private void SetPairingButtons(PairingButtons buttons)
        {
            if (pairingButtons.Count>0)
            {
                if (buttons != pairingButtons[0])
                {
                    
                }
            }
            pairingButtons.Add(buttons);
        
            if (pairingButtons.Count>=2)
            {
                if (pairingButtons[0].GetComponent<PairingButtons>().ID == pairingButtons[1].GetComponent<PairingButtons>().ID && pairingButtons[0] != pairingButtons[1])
                {
                    BusSystem.CallPlayerSetAnim(2);
                    BusSystem.CallAudioChange(8);
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
                    BusSystem.CallPlayerSetAnim(3);
                    BusSystem.CallAudioChange(9);
              
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
                StartCoroutine(LevelEndAnim());
            }
        }
        private IEnumerator LevelEndAnim()
        {
            buttonsBackGround.transform.DOMoveY(-1173, 1f);
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
    }
}
