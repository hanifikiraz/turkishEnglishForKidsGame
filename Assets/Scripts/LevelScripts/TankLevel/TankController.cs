using DG.Tweening;
using UnityEngine;

namespace LevelScripts.TankLevel
{
    public class TankController : MonoBehaviour
    {
        [SerializeField] private GameObject turret;
        [SerializeField] private GameObject bullet;
        [SerializeField] private Transform shotPos;
        public float minRotationX = -45f;  // Minimum Z rotasyonu
        public float maxRotationX = 45f;   // Maksimum Z rotasyonu
        public float turretSpeed = 100f;  // Rotasyon hızı
        private int moveType;
        public float rayDistance = 10.0f;
        private Transform target;
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
            RaycastObject();
        }

        private void RaycastObject()
        {
            
            // Y ekseninde yukarı doğru bir ray fırlat
            Ray ray = new Ray(shotPos.position, shotPos.transform.up);
            RaycastHit hit;

            // Raycast işlemi
            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                Debug.Log("Raycast hit: " + hit.collider.gameObject.name);

                // Çarptığı nokta kırmızı bir küp olarak çizilecek
                Debug.DrawLine(ray.origin, hit.point, Color.red);
                target = hit.transform;
            }
            else
            {
                // Çarpmadığı durum için ray yeşil olarak çizilecek
                Vector3 endPoint = ray.origin + ray.direction * rayDistance;
                Debug.DrawLine(ray.origin, endPoint, Color.green);
            }

            // Eğer bir hedef varsa, hedefin pozisyonunu kullanabilirsiniz
            if (target != null)
            {
                Vector3 targetPosition = target.position;
                // Hedefin pozisyonunu kullanarak bir şeyler yapabilirsiniz
                // Örneğin, hedefe doğru hareket edebilirsiniz.
            }
            
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

        public void ShotBullet()
        {
            GameObject instBullet = Instantiate(bullet, shotPos.transform.position, Quaternion.identity);
            instBullet.transform.DOLocalMove(target.position, 1f).OnComplete((() =>
            {
                Destroy(instBullet);
            }));
        }
        
    }
}
