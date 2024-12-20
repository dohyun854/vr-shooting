using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public Transform player;
    public float attackDistance = 2f; // 공격을 시작할 거리
    private Animator animator;
    private bool isAttacking = false;

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
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    private void Update()
    {
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
