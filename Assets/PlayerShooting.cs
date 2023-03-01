using System.Collections.Generic;
using UnityEngine;


namespace Slime {
    public class PlayerShooting : MonoBehaviour {
        public float fireRate = 0.5f;   // �������� ��������
        /* public Transform gunBarrel;*/     // �����, �� ������� �������� �����
        public float shootingRange = 10f;   // ����������, �� ������� ����� ����� ������

        private float nextFireTime;     // ����� ���������� ��������
        private List<EnemyHealth> enemiesInRange;   // ������ ������, ����������� � ���� ��������� ������
        private EnemyHealth target;     // ���� ��� ��������

        public float projectileSpeed; // �������� ������ �������
        public float launchAngle; // ���� ������� �������
        public Transform firePoint; // ����� ������� �������
        public GameObject projectilePrefab; // ������ �������


        private void Awake() {
            enemiesInRange = new List<EnemyHealth>();
        }

        private void Update() {
            // ������� ���� ������ � ���� ���������
            Collider[] colliders = Physics.OverlapSphere(transform.position, shootingRange);
            enemiesInRange.Clear();

            foreach (Collider c in colliders) {
                EnemyHealth enemyHealth = c.GetComponent<EnemyHealth>();
                if (enemyHealth != null) {
                    enemiesInRange.Add(enemyHealth);
                }
            }

            // ���� ���� ����, ��������� � ����� � ��������
            if (target != null) {
                if (target.currentHealth <= 0) {
                    target = null;
                }
                else {
                    Shoot();
                }
            }
            // ���� ���� ���, �������� ���������
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
                // ��� ��� ��������



                // ������� ��������� �������
                GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

                // ��������� �������������� � ������������ �������� �� ������ ���� � �������� �������
                float horizontalSpeed = projectileSpeed * Mathf.Cos(launchAngle * Mathf.Deg2Rad);
                float verticalSpeed = projectileSpeed * Mathf.Sin(launchAngle * Mathf.Deg2Rad);

                // ������ ��������� �������� �������
                projectile.GetComponent<Rigidbody>().velocity = new Vector3(horizontalSpeed, verticalSpeed, 0);
            }

        }
    }
}
