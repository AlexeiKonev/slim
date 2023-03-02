using UnityEngine;

namespace Slime {
    public class PlayerMovement : MonoBehaviour {
        public float speed = 5f;
        public float stoppingDistance = 2f;
        public Animator animator;

      [SerializeField]  private Transform target;
        public bool isMoving = true;

        void Start() {
            target = GameObject.FindGameObjectWithTag("stop").transform;
        }

        void Update() {

            if (isMoving) {
                transform.position += transform.forward * speed * Time.deltaTime;
                //animator.SetBool("isMoving", true);
                //isMoving = true;
            }
            else {
                //animator.SetBool("isMoving", false);
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

