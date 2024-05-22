using UnityEngine;

namespace Unit
{
    public class UnitHomeButton : MonoBehaviour
    {
        [SerializeField] private GameObject backMenuObject;
        [SerializeField] private GameObject myCanvas;

        public void SetCanvas()
        {
            backMenuObject.SetActive(true);
            myCanvas.SetActive(false);
        }
    }
}
