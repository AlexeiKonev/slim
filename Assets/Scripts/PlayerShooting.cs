using System.Collections.Generic;
using UnityEngine;


namespace Slime {
    public class PlayerShooting : MonoBehaviour {
        public float fireRate = 0.5f;   // Скорость стрельбы
        /* public Transform gunBarrel;*/     // Точка, из которой стреляет игрок
        public float shootingRange = 10f;   // Расстояние, на котором игрок видит врагов

        private float nextFireTime;     // Время следующего выстрела
        private List<EnemyHealth> enemiesInRange;   // Список врагов, находящихся в зоне видимости игрока
        private EnemyHealth target;     // Цель для стрельбы

        public float projectileSpeed; // скорость полета снаряда
        public float launchAngle; // угол запуска снаряда
        public Transform firePoint; // точка запуска снаряда
        public GameObject projectilePrefab; // префаб снаряда


        private void Awake() {
            enemiesInRange = new List<EnemyHealth>();
        }

        private void Update() {
            // Находим всех врагов в зоне видимости
            Collider[] colliders = Physics.OverlapSphere(transform.position, shootingRange);
            enemiesInRange.Clear();

            foreach (Collider c in colliders) {
                EnemyHealth enemyHealth = c.GetComponent<EnemyHealth>();
                if (enemyHealth != null) {
                    enemiesInRange.Add(enemyHealth);
                }
            }

            // Если есть цель, проверяем её жизни и стреляем
            if (target != null) {
                if (target.currentHealth <= 0) {
                    target = null;
                }
                else {
                    Shoot();
                }
            }
            // Если цели нет, выбираем ближайшую
            else if (enemiesInRange.Count > 0) {
                float closestDistance = float.MaxValue;
                foreach (EnemyHealth enemy in enemiesInRange) {
                    float distance = Vector3.Distance(transform.position, enemy.transform.position);
                    if (distance < closestDistance) {
                        closestDistance = distance;
                        target = enemy;
                    }
                }
            }
        }

        private void Shoot() {
            if (Time.time > nextFireTime) {
                nextFireTime = Time.time + fireRate;
                // Код для стрельбы



                // Создаем экземпляр снаряда
                GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

                // Вычисляем горизонтальную и вертикальную скорости на основе угла и скорости снаряда
                //float horizontalSpeed = projectileSpeed * Mathf.Cos(launchAngle * Mathf.Deg2Rad);
                //float verticalSpeed = projectileSpeed * Mathf.Sin(launchAngle * Mathf.Deg2Rad);

                // Задаем начальную скорость снаряда
                //projectile.GetComponent<Rigidbody>().velocity = new Vector3(horizontalSpeed, verticalSpeed, 0);
            }

        }
    }
}
