using System;
using UnityEngine;
namespace Slime {

    public class EnemyHealth : MonoBehaviour {
        public int startingHealth = 100;             // Начальное значение здоровья для врага

        public int currentHealth;             // Текущее состояние здоровья противника       
        public float sinkSpeed = 2.5f;                // Скорость, с которой враг проваливается сквозь пол, когда мертв
        public int scoreValue = 10;                  // Сумма, добавляемая к счету игрока, когда враг умирает
        public AudioClip deathClip;                     // Звук, который воспроизводится, когда враг умирает
        public GameObject damageTextPrefab;
        public Animator anim;                              // Ссылка на компонент animator
        public AudioSource enemyAudio;                        // Ссылка на компонент AudioSource
        public ParticleSystem hitParticles;                 // Ссылка на систему частиц при попадании во врага
        public CapsuleCollider capsuleCollider;             // Ссылка на компонент капсульного коллайдера
        bool isDead;                                // Логическое значение для проверки того, мертв ли враг
        bool isSinking;

        public Action<GameObject> OnDeath { get; internal set; }

        void Awake() {

            anim = GetComponent<Animator>();
            enemyAudio = GetComponent<AudioSource>();
            hitParticles = GetComponentInChildren<ParticleSystem>();
            capsuleCollider = GetComponent<CapsuleCollider>();


            currentHealth = startingHealth;
        }

        void Update() {
            // должен ли враг проваливаться сквозь пол
            if (isSinking) {
                // Перемещайте врага вниз на скорость погружения в каждом кадре
                transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
            }
        }

        public void TakeDamage(int damageAmount) {
            // Check if the enemy is dead
            if (isDead)
                return;

            // Play the hit particles at the hit point
            //hitParticles.transform.position = hitPoint;
            //hitParticles.Play();

            // Subtract the amount of damage from the current health
            currentHealth -= damageAmount;

            // Play the enemy hurt sound
            //enemyAudio.Play();

            // Check if the enemy is dead
            if (currentHealth <= 0) {
                Death();
            }
            else {
                // создать текст урона над головой врага
                GameObject damageTextObject = Instantiate(damageTextPrefab, transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);
                DamageText damageText = damageTextObject.GetComponent<DamageText>();
                damageText.SetText(damageAmount);
            }
        }

        void Death() {
            // Set the isDead flag to true
            isDead = true;

            // Disable the capsule collider so the enemy can't be hit anymore
            capsuleCollider.enabled = false;

            // Play the death animation and sound
            anim.SetTrigger("Dead");
            enemyAudio.clip = deathClip;
            enemyAudio.Play();
        }

        public void StartSinking() {
            // Disable the nav mesh agent so the enemy doesn't move anymore
            GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;

            // Set the isSinking flag to true
            isSinking = true;

            // Add the score value to the player's score
            ScoreManager.instance.score += scoreValue;

            // Destroy the enemy after 2 seconds
            Destroy(gameObject, 2f);
        }
    }

}