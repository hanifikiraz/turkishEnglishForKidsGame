using UnityEngine;

namespace LevelScripts.CollectFruits
{
    public class BasketMove : MonoBehaviour
    {
        [SerializeField] private float basketSpeed;
        public float minX = -5f;  // Minimum X değeri
        public float maxX = 5f;   // Maksimum X değeri
        private int moveType;
        private void OnEnable()
        {
            BusSystem.OnBasketMove += MoveType;
        }

        private void OnDisable()
        {
            BusSystem.OnBasketMove -= MoveType;
        }
        private void MoveType(int value)
        {
            moveType = value;
        }
        void Update()
        {
            float moveInput = 0f;
            if (moveType == 1)
            {
                moveInput = -1f;
            }
            else if (moveType == 2)
            {
                moveInput = 1f;
            }
            else if (moveType == 0)
            {
                moveInput = 0f;
            }

            Vector3 moveDirection = new Vector3(moveInput, 0f, 0);

            // Yeni pozisyonu hesapla
            Vector3 newPosition = transform.position + moveDirection * basketSpeed * Time.deltaTime;

            // X değerini sınırla
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

            // Yeni pozisyonu uygula
            transform.position = newPosition;
        }
    }
}
