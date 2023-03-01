using UnityEngine;
namespace Slime {
    public class EnemyAttack : MonoBehaviour {
        public float attackRange = 1f; // дальность атаки
        public int attackDamage = 10; // урон атаки
        public float attackDelay = 1f; // задержка между атаками
        public float attackDuration = 0.5f; // длительность анимации атаки
        public Animator animator; // аниматор врага
        public LayerMask playerLayer; // слой игрока

        [SerializeField] private Transform player; // игрок
        [SerializeField] private bool isAttacking = false; // флаг, показывающий, атакует ли враг сейчас
        private float attackTime = 0f; // время последней атаки

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

                    // направляем врага на игрока
                    transform.LookAt(player);

                    // запускаем анимацию атаки
                    animator.SetTrigger("Attack");

                    // наносим урон игроку с небольшой задержкой, чтобы анимация успела сработать
                    Invoke("DealDamage", attackDuration * 0.5f);
                }
            }
        }
        void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Player")) {
                animator.SetTrigger("Attack");  // Запустить анимацию атаки врага
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

        // Отрисовка сферы для отладки
        void OnDrawGizmosSelected() {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRange);
        }
    }
}

