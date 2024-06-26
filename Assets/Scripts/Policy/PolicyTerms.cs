using UnityEngine;

namespace Policy
{
    public class PolicyTerms : MonoBehaviour
    {
        public void OpenPolicy()
        {
            Application.OpenURL ("https://liberta.com.tr/privacy-policy");
        }

        public void OpenTerms()
        {
            Application.OpenURL ("https://liberta.com.tr/terms");
        }
    }
}
