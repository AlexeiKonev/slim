using UnityEngine;
namespace Slime {
    public class EnemyMovement : MonoBehaviour {
        public float speed = 5f; // скорость движения врага
        public float detectDistance = 10f; // расстояние, на котором враг замечает игрока

        private Transform player; // ссылка на трансформ игрока
        private bool playerDetected = false; // флаг для определения, замечен ли игрок

        private void Start() {
            player = GameObject.FindGameObjectWithTag("Player").transform; // находим игрока по тегу
        }

        private void Update() {
            // определяем расстояние между врагом и игроком
            float distance = Vector3.Distance(transform.position, player.position);

            // если расстояние меньше detectDistance, то враг замечает игрока
            if (distance < detectDistance) {
                playerDetected = true;
            }

            // если враг заметил игрока, то движемся к нему
            if (playerDetected) {
                // вычисляем направление к игроку
                Vector3 direction = (player.position - transform.position).normalized;

                // перемещаем врага в направлении игрока
                transform.position += direction * speed * Time.deltaTime;
            }
        }
    }
}