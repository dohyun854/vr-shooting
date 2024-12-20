using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHp = 1; // 최대 HP
    private int currentHp; // 현재 HP

    void Start()
    {
        currentHp = maxHp; // HP 초기화
    }

    void OnCollisionEnter(Collision collision)
    {
        // 총알과 충돌한 경우만 처리
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(1); // 데미지 1 적용
            Debug.Log("적 피격! 남은 HP: " + currentHp);

            // 총알 파괴
            Destroy(collision.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage; // HP 감소
        if (currentHp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("적 처치됨!");
    }
}