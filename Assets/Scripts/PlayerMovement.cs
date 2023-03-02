using UnityEngine;

namespace Slime {
    public class PlayerMovement : MonoBehaviour {
        public float speed = 5f;
        public float stoppingDistance = 2f;
        public Animator animator;

        private Transform target;
        private bool isMoving = false;

        void Start() {
            target = GameObject.FindGameObjectWithTag("Enemy").transform;
        }

        void Update() {
            if (Vector3.Distance(transform.position, target.position) > stoppingDistance) {
                transform.position += transform.forward * speed * Time.deltaTime;
                animator.SetBool("isMoving", true);
                isMoving = true;
            }
            else {
                animator.SetBool("isMoving", false);
                isMoving = false;
            }
        }

        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Enemy")) {
                animator.SetBool("isMoving", false);
                isMoving = false;
            }
        }
    }
}

