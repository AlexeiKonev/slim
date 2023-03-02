using Slime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {
    public GameObject[] enemyPrefabs;
    public int numEnemies;
    public float spawnRadius;
    public float spawnDelay;

    private int enemiesRemaining;
    private bool isGeneratingEnemies;

    void Start() {
        isGeneratingEnemies = false;
        enemiesRemaining = 0;
    }

    void Update() {
        if (!isGeneratingEnemies && enemiesRemaining == 0) {
            StartCoroutine(GenerateEnemies());
        }
    }

    IEnumerator GenerateEnemies() {
        isGeneratingEnemies = true;

        for (int i = 0; i < numEnemies; i++) {
            Vector3 spawnPos = Random.insideUnitSphere * spawnRadius;
            spawnPos.y = 0;
            Quaternion spawnRot = Quaternion.Euler(0, Random.Range(0f, 360f), 0);

            GameObject enemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], transform.position + spawnPos, spawnRot);

            enemy.GetComponent<EnemyHealth>().OnDeath += EnemyDestroyed;

            enemiesRemaining++;
            yield return new WaitForSeconds(spawnDelay);
        }

        isGeneratingEnemies = false;
    }

    void EnemyDestroyed(GameObject enemy) {
        enemiesRemaining--;
        if (enemiesRemaining == 0) {
            Debug.Log("All enemies destroyed, generating new wave...");
        }
    }
}
