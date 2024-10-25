using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public GameObject npcPrefab; // NPC 프리팹
    public float spawnInterval = 3f; // NPC 생성 간격
    public Transform[] spawnPoints; // NPC가 생성될 위치 배열

    private float timer;

    void Start()
    {
        timer = spawnInterval; // 타이머 초기화
    }

    void Update()
    {
        timer -= Time.deltaTime; // 타이머 업데이트
        if (timer <= 0)
        {
            SpawnNPC(); // NPC 생성
            timer = spawnInterval; // 타이머 재설정
        }
    }

    void SpawnNPC()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length); // 랜덤 위치 선택
        Instantiate(npcPrefab, spawnPoints[spawnIndex].position, Quaternion.identity); // NPC 생성
    }
}
