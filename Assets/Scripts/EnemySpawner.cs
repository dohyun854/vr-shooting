using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;
    public float spawnDistance = 20f;
    public float spawnInterval = 3f;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Vector3 spawnPosition = player.position + (Quaternion.Euler(0, Random.Range(-45, 45), 0) * Vector3.forward * spawnDistance);
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            
            Vector3 directionToPlayer = (player.position - spawnPosition).normalized;
            directionToPlayer = Vector3.ProjectOnPlane(directionToPlayer, Vector3.up);

            Quaternion rotationToPlayer = Quaternion.LookRotation(directionToPlayer);
            enemy.transform.rotation = rotationToPlayer;

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
