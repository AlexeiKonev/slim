using UnityEngine;
namespace Slime {
    public class PlayerAttack : MonoBehaviour {
        public float attackRange = 1f; // дальность атаки
        public int attackDamage = 10; // урон атаки
        public float attackDelay = 1f; // задержка между атаками
        public float attackDuration = 0.5f; // длительность анимации атаки
        public Animator animator; // аниматор врага
        public LayerMask EnemyLayer; // слой игрока

        [SerializeField] private Transform Enemy;
        public bool isAttacking = false; // флаг, показывающий, атакует ли враг сейчас
        private float attackTime = 0f; // время последней атаки

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

                    // направляем   игрока на врага
                    transform.LookAt(Enemy);

                    // запускаем анимацию атаки
                    animator.SetTrigger("Attack");

                    // наносим урон  с небольшой задержкой, чтобы анимация успела сработать
                    Invoke("DealDamage", attackDuration * 0.5f);
                }
            }
        }
        void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Enemy")) {
                animator.SetTrigger("Attack");  // Запустить анимацию атаки врага
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

        // Отрисовка сферы для отладки
        void OnDrawGizmosSelected() {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRange);
        }
    }
}

