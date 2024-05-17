using UnityEngine;

namespace LevelScripts.TankLevel
{
    public class TankController : MonoBehaviour
    {
        [SerializeField] private GameObject turret;
        
        public float minRotationX = -45f;  // Minimum Z rotasyonu
        public float maxRotationX = 45f;   // Maksimum Z rotasyonu
        public float turretSpeed = 100f;  // Rotasyon hızı
        private int moveType;
        private void OnEnable()
        {
            BusSystem.OnTankMove += MoveType;
        }

        private void OnDisable()
        {
            BusSystem.OnTankMove -= MoveType;
        }
        private void MoveType(int value)
        {
            moveType = value;
        }
        void Update()
        {
            RotationTurret();
            
        }

        private void RotationTurret()
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

            // Şu anki rotasyonu Euler açıları olarak al
            Vector3 currentRotation = turret.transform.localRotation.eulerAngles;

            // X rotasyonunu -180 ile 180 arasında tut
            if (currentRotation.x > 180) 
                currentRotation.x -= 360;

            // Hedef rotasyonu hesapla
            float targetRotationX = currentRotation.x + moveInput * turretSpeed * Time.deltaTime;

            // Hedef rotasyonu sınırlara çek
            targetRotationX = Mathf.Clamp(targetRotationX, minRotationX, maxRotationX);

            // Yeni rotasyonu ayarla
            turret.transform.localRotation = Quaternion.Euler(new Vector3(targetRotationX, currentRotation.y, currentRotation.z));
        }
        
    }
}
