using UnityEngine;

namespace Menu
{
  public class MenuSelectController : MonoBehaviour
  {
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject openCanvas;
    public void OpenStudentCanvas()
    {
      openCanvas.SetActive(true);
      mainMenuCanvas.SetActive(false);
    }

    public void BackToMainMenu()
    {
      mainMenuCanvas.SetActive(true);
      openCanvas.SetActive(false);
    }
  
  }
}
