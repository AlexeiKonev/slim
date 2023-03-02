using Slime;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public float speed = 10f;
    public int damage = 10;

    private Transform target;

    void Start() {
        //Destroy(gameObject, 50f);
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Enemy")) {
            target = other.transform;
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = (target.position - transform.position).normalized * speed;
        }
    }

    void FixedUpdate() {
        if (target != null) {
            transform.LookAt(target.position);
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage/*, collision.gameObject.transform.position*/);
        }
        Destroy(gameObject);
    }
}

