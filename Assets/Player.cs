using UnityEngine;
using UnityEngine.UI;
namespace NewSlime {
    public class Player : MonoBehaviour {
        //UI
        Text healthText;
        Text moneyText;

        //Player parametrs
        int attackPlayer;
        int healthPlayer;
        int healPlayer;
        int moneyPlayer;
        float speedPlayer;

        //bullet
        [SerializeField] GameObject bullet;
        //current enemy
        public    Transform enemyTransform;



        // Start is called before the first frame update
        void Start() {

        }

        // Update is called once per frame
        void Update() {
          
        }
        //attack
        //public void AttackPlayer(Bullet bullet) {





        //    GameObject closestEnemy = FindEnemy();

        //    if (closestEnemy != null) {

        //        GameObject projectile = Instantiate(bullet.transform.gameObject);

        //    }
        //}


        public void AttackPlayer2() {

           enemyTransform = FindEnemy();
            GameObject projectile = Instantiate(bullet, transform.position, Quaternion.LookRotation(enemyTransform.position));
            //projectile.GetComponent<Bullet>().enemy = enemyTransform;

        }
        private Transform FindEnemy() {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            if (enemies.Length == 0)
                return null;

            Transform nearestEnemy = enemies[0].transform;
            float distanceForNearestEnemy = Vector3.Distance(nearestEnemy.transform.position, transform.position);
            if (enemies.Length > 1) {
                for (int i = 1; i < enemies.Length; i++) {
                    Transform currentEnemy = enemies[i].transform;
                    float distanceForCurrentEnemy = Vector3.Distance(currentEnemy.transform.position, transform.position);
                    if (distanceForCurrentEnemy < distanceForNearestEnemy) {
                        distanceForNearestEnemy = distanceForCurrentEnemy;
                        nearestEnemy = currentEnemy;
                    }
                }
            }

            return nearestEnemy;
        }


    }

}

