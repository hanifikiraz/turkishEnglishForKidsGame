using UnityEngine;

namespace LevelScripts.LetterGame
{
    public class LetterSelection : MonoBehaviour
    {
        public enum LetterType
        {
            Transparent,
            NoTransparent
        }

        public enum Letters
        {
            A,B,C,D,E,F,G,H,J,K,I,L,M,N,O,P,R,S,T,Y,Z,U,V,W,Q,X
        }

        public LetterType letterType;
        public Letters letters;
        public bool isTaked;
        


    }
}
