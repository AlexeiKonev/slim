using Slime;
using System;
using UnityEngine;

namespace NewSlime {



    public class Bullet : MonoBehaviour {
        public float speed = 10f; // Скорость пули
        public int damage = 10; // Урон, который наносит пуля

        private Transform target; // Цель пули (враг)

        public void SetTarget(Transform enemyTransform) {
            target = enemyTransform; // Установка цели
        }

        private void Update() {
            if (target == null) {
                // Если цель была уничтожена, уничтожаем и пулю
                Destroy(gameObject);
                return;
            }

            // Направление движения пули к цели
            Vector3 direction = target.position - transform.position;

            // Расстояние до цели
            float distanceThisFrame = speed * Time.deltaTime;

            // Если расстояние до цели меньше, чем расстояние, которое пуля проходит за текущий кадр, то пуля достигла цели
            if (direction.magnitude <= distanceThisFrame) {
                HitTarget(); // Вызов метода попадания по цели
                return;
            }

            // Перемещаем пулю в направлении цели
            transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        }

        private void HitTarget() {
            // Наносим урон врагу
            EnemyHealth enemyHealth = target.GetComponent<EnemyHealth>();
            if (enemyHealth != null) {
                enemyHealth.TakeDamage(damage);
            }

            // Уничтожаем пулю
            Destroy(gameObject);
        }
    }

}