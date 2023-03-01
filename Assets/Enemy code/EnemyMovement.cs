using UnityEngine;
namespace Slime {
    public class EnemyMovement : MonoBehaviour {
        public float speed = 5f; // �������� �������� �����
        public float detectDistance = 10f; // ����������, �� ������� ���� �������� ������
        EnemyAttack ea;
        private Transform player; // ������ �� ��������� ������
        private bool playerDetected = false; // ���� ��� �����������, ������� �� �����

        private void Start() {
            ea =GetComponent<EnemyAttack>();
            player = GameObject.FindGameObjectWithTag("Hit").transform; // ������� ������ �� ����
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
                ea.animator.SetTrigger("Walk");
                transform.position += direction * speed * Time.deltaTime;
                 
            }
        }
    }
}