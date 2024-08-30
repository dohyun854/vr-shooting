using UnityEngine;

public class NPC : MonoBehaviour
{
    public float speed = 5f; // NPC 이동 속도
    private Transform player; // 플레이어 위치

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // 플레이어 찾기
    }

    void Update()
    {
        if (player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime); // 플레이어를 향해 이동
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // 플레이어에게 데미지 주는 코드
            Destroy(gameObject); // NPC 제거
        }
    }
}
