using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public Transform player;
    public float attackDistance = 2f;
    private Animator animator;
    private bool isAttacking = false;
    private bool isDead = false;
    public int maxHp = 1;
    private int currentHp;

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on Enemy.");
        }

        if (player == null)
        {
            Debug.LogError("Player Transform is not set in Enemy script.");
        }
        currentHp = maxHp;
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(1);
            Debug.Log("적 피격! 남은 HP: " + currentHp);
            Destroy(collision.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return; // 이미 죽은 상태면 더 이상 처리하지 않음

        isDead = true;
        speed = 0;
        animator.SetTrigger("Die");
        Debug.Log("적 처치됨!");
    }

    private void Update()
    {
        if (isDead) return; // 죽은 상태에서는 더 이상 업데이트 하지 않음

        if (!isAttacking)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer > attackDistance)
            {
                Vector3 direction = (player.position - transform.position).normalized;
                transform.position += direction * speed * Time.deltaTime;

                Vector3 lookDirection = new Vector3(player.position.x - transform.position.x, 0, player.position.z - transform.position.z);
                transform.rotation = Quaternion.LookRotation(lookDirection);

                if (animator != null)
                {
                    animator.SetFloat("Speed", speed);
                }
            }
            else
            {
                isAttacking = true;
                speed = 0;

                if (animator != null)
                {
                    animator.SetTrigger("Attack");
                }
            }
        }
        else
        {
            if (animator != null && !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                animator.SetTrigger("Attack");
            }

            Vector3 lookDirection = new Vector3(player.position.x - transform.position.x, 0, player.position.z - transform.position.z);
            transform.rotation = Quaternion.LookRotation(lookDirection);
        }
    }
}
