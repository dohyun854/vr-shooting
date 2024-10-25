using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;
    public float spawnDistance = 10f;
    public float spawnInterval = 3f;

    private void Start()
    {
        // 스폰을 주기적으로 실행
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Vector3 spawnPosition = player.position + (Quaternion.Euler(0, Random.Range(-45, 45), 0) * Vector3.forward * spawnDistance);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
