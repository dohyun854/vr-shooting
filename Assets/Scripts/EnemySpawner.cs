using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;
    public float spawnDistance = 20f;
    public float spawnInterval = 3f;
    public float levelUpInterval = 10f;
    public float spawnSpeedMultiplier = 0.9f;
    public float enemySpeedMultiplier = 1.1f;
    public float enemyHpMultiplier = 1.1f;

    private int level = 1;
    private float currentSpawnInterval;
    private float currentEnemySpeed;
    private float currentmaxHp;

    private void Start()
    {
        currentSpawnInterval = spawnInterval;
        currentEnemySpeed = 1f;
        StartCoroutine(SpawnEnemy());
        StartCoroutine(LevelUp());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Vector3 spawnPosition = player.position + (Quaternion.Euler(0, Random.Range(-45, 45), 0) * Vector3.forward * spawnDistance);
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            Enemy enemyScript = enemy.GetComponent<Enemy>();
            enemyScript.player = player;

            Vector3 directionToPlayer = (player.position - spawnPosition).normalized;
            directionToPlayer = Vector3.ProjectOnPlane(directionToPlayer, Vector3.up);

            Quaternion rotationToPlayer = Quaternion.LookRotation(directionToPlayer);
            enemy.transform.rotation = rotationToPlayer;

            enemyScript.SetSpeed(currentEnemySpeed);
            enemyScript.SetmaxHp(currentmaxHp);

            enemy.SetActive(true);

            yield return new WaitForSeconds(currentSpawnInterval);
        }
    }

    private IEnumerator LevelUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(levelUpInterval);
            level++;
            PlayerPrefs.SetInt("LEVEL", level);

            currentSpawnInterval = Mathf.Max(0.5f, currentSpawnInterval * spawnSpeedMultiplier);
            currentEnemySpeed *= enemySpeedMultiplier;
            currentmaxHp *= enemyHpMultiplier;
        }
    }
}
