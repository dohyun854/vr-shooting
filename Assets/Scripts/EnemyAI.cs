using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public Transform player;
    private Animator animator;
    private bool isAttacking = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    private void Update()
    {
        if (isAttacking) return;

        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            if (animator != null)
            {
                animator.SetFloat("Speed", speed);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isAttacking = true;
            speed = 0;

            if (animator != null)
            {
                animator.SetTrigger("Attack");
            }
        }
    }
}
