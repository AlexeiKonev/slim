using UnityEngine;
namespace Slime {
    public class EnemyAttack : MonoBehaviour {
        public float attackRange = 1f; // ��������� �����
        public int attackDamage = 10; // ���� �����
        public float attackDelay = 1f; // �������� ����� �������
        public float attackDuration = 0.5f; // ������������ �������� �����
        public Animator animator; // �������� �����
        public LayerMask playerLayer; // ���� ������

        [SerializeField] private Transform player; // �����
        public bool isAttacking = false; // ����, ������������, ������� �� ���� ������
        private float attackTime = 0f; // ����� ��������� �����

        public SphereCollider enemyCollider;
        void Start() {
            enemyCollider = GetComponent<SphereCollider>();
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        void Update() {
            if (!isAttacking && Time.time >= attackTime + attackDelay) {
                float distanceToPlayer = Vector3.Distance(transform.position, player.position);
                if (distanceToPlayer <= attackRange) {
                    isAttacking = true;
                    attackTime = Time.time;

                    // ���������� ����� �� ������
                    transform.LookAt(player);

                    // ��������� �������� �����
                    animator.SetTrigger("Attack");

                    // ������� ���� ������ � ��������� ���������, ����� �������� ������ ���������
                    Invoke("DealDamage", attackDuration * 0.5f);
                }
            }
        }
        void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Player")) {
                animator.SetTrigger("Attack");  // ��������� �������� ����� �����
            }
        }


        private void DealDamage() {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange, playerLayer);
            foreach (Collider hitCollider in hitColliders) {
                PlayerHealth playerHealth = hitCollider.GetComponent<PlayerHealth>();
                if (playerHealth != null) {
                    playerHealth.TakeDamage(attackDamage);
                }
            }
            isAttacking = false;
        }

        // ��������� ����� ��� �������
        void OnDrawGizmosSelected() {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRange);
        }
    }
}

