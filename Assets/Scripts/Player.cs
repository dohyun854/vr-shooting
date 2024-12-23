using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHp = 100; // 최대 HP
    private int currentHp;

    private void Start()
    {
        currentHp = maxHp;
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        Debug.Log("플레이어 HP: " + currentHp);

        if (currentHp <= 0)
        {
            Die();
        }
    }

    public int GetCurrentHp()
    {
        return currentHp;
    }

    private void Die()
    {
        Debug.Log("플레이어가 죽었습니다!");
        // 사망 처리 (예: 게임 오버 화면 표시)
    }
}
