using UnityEngine;
namespace Slime {
    public class EnemyMovement : MonoBehaviour {
        public float speed = 5f; // �������� �������� �����
        public float detectDistance = 10f; // ����������, �� ������� ���� �������� ������

        private Transform player; // ������ �� ��������� ������
        private bool playerDetected = false; // ���� ��� �����������, ������� �� �����

        private void Start() {
            player = GameObject.FindGameObjectWithTag("Player").transform; // ������� ������ �� ����
        }

        private void Update() {
            // ���������� ���������� ����� ������ � �������
            float distance = Vector3.Distance(transform.position, player.position);

            // ���� ���������� ������ detectDistance, �� ���� �������� ������
            if (distance < detectDistance) {
                playerDetected = true;
            }

            // ���� ���� ������� ������, �� �������� � ����
            if (playerDetected) {
                // ��������� ����������� � ������
                Vector3 direction = (player.position - transform.position).normalized;

                // ���������� ����� � ����������� ������
                transform.position += direction * speed * Time.deltaTime;
            }
        }
    }
}