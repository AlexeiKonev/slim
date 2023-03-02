using UnityEngine;
namespace Slime {
    public class PlayerAttack : MonoBehaviour {
        public float attackRange = 1f; // ��������� �����
        public int attackDamage = 10; // ���� �����
        public float attackDelay = 1f; // �������� ����� �������
        public float attackDuration = 0.5f; // ������������ �������� �����
        public Animator animator; // �������� �����
        public LayerMask EnemyLayer; // ���� ������

        [SerializeField] private Transform Enemy;
        public bool isAttacking = false; // ����, ������������, ������� �� ���� ������
        private float attackTime = 0f; // ����� ��������� �����

        public SphereCollider enemyCollider;
        void Start() {
            enemyCollider = GetComponent<SphereCollider>();
            Enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        }

        void Update() {
            if (!isAttacking && Time.time >= attackTime + attackDelay) {
                float distanceToPlayer = Vector3.Distance(transform.position, Enemy.position);
                if (distanceToPlayer <= attackRange) {
                    isAttacking = true;
                    attackTime = Time.time;

                    // ����������   ������ �� �����
                    transform.LookAt(Enemy);

                    // ��������� �������� �����
                    animator.SetTrigger("Attack");

                    // ������� ����  � ��������� ���������, ����� �������� ������ ���������
                    Invoke("DealDamage", attackDuration * 0.5f);
                }
            }
        }
        void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Enemy")) {
                animator.SetTrigger("Attack");  // ��������� �������� ����� �����
            }
        }


        private void DealDamage() {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange, EnemyLayer);
            foreach (Collider hitCollider in hitColliders) {
                EnemyHealth enemyHealth = hitCollider.GetComponent<EnemyHealth>();
                if (enemyHealth != null) {
                    enemyHealth.TakeDamage(attackDamage);
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

