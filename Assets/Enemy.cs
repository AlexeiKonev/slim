using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Slime {
    public class Enemy : MonoBehaviour {

        public float moveSpeed; // скорость передвижения врага
        public int damageAmount; // количество урона, наносимого игроку
        public Transform target; // цель врага (игрок)
        public float attackRange; // дистанция, на которой враг может атаковать игрока

        private void Update() {
            if (target != null) {
                // Вычисляем расстояние до цели (игрока)
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                // Если расстояние до цели меньше или равно дистанции атаки, то атакуем
                if (distanceToTarget <= attackRange) {
                    Attack();
                }
                // Иначе двигаемся к цели
                else {
                    MoveTowardsTarget();
                }
            }
        }

        private void MoveTowardsTarget() {
            // Находим направление к цели (игроку)
            Vector3 direction = (target.position - transform.position).normalized;

            // Двигаемся в направлении цели
            transform.position += direction * moveSpeed * Time.deltaTime;
        }

        private void Attack() {
            // Наносим урон игроку
            target.GetComponent<PlayerHealth>().TakeDamage(damageAmount);
        }

    }
}
