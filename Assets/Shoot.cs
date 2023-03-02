using NewSlime;
using UnityEngine;

public class Shoot : MonoBehaviour {
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public Transform enemyPoint;

    private void Update() {
        if (Input.GetButtonDown("Fire1")) {
            ShootBullet();
        }
    }

    private void ShootBullet() {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        Bullet bulletComponent = bullet.GetComponent<Bullet>();
        if (bulletComponent != null) {
            bulletComponent.SetTarget(enemyPoint);
        }
    }
}
