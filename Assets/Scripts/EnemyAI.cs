using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public Transform player;
    public float attackDistance = 2f;
    private Animator animator;
    private bool isAttacking = false;
    public float maxHp = 1;
    private float currentHp;
    private bool isDead = false;
    public int Score;
    private AudioSource audioSource;
    public AudioClip dieSound; 

    public int damagePerHit = 10;
    public float attackInterval = 1.5f;
    private Coroutine attackCoroutine;
    GaScore score;

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = dieSound;
    }
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

    public void SetmaxHp(float newmaxHP)
    {
        maxHp = newmaxHP;
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
        if (isDead) return;

        isDead = true;
        speed = 0;
        animator.SetTrigger("Die");
        Debug.Log("적 처치됨!");
        gameObject.layer = LayerMask.NameToLayer("DeadEnemy");
        StopAttacking();
        StartCoroutine(StopMovementAfterDie());
        Destroy(gameObject, 3f);
        audioSource.Play(); 


        //score.GetScore();
        //score.SetText();
        
    }
    

    private IEnumerator StopMovementAfterDie()
    {
        yield return new WaitForSeconds(1f);
        transform.position = transform.position;
        transform.rotation = transform.rotation;
    }

    private void Update()
    {
        if (isDead) return;

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

                if (attackCoroutine == null)
                {
                    attackCoroutine = StartCoroutine(AttackPlayer());
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

    private IEnumerator AttackPlayer()
    {
        while (isAttacking && !isDead)
        {
            Player playerScript = player.GetComponent<Player>();
            if (playerScript != null)
            {
                playerScript.TakeDamage(damagePerHit);
                // Debug.Log("Player attacked! HP Left: " + playerScript.GetCurrentHp());
            }

            yield return new WaitForSeconds(attackInterval);
        }

        attackCoroutine = null;
    }

    private void StopAttacking()
    {
        isAttacking = false;
        if (attackCoroutine != null)
        {
            StopCoroutine(attackCoroutine);
            attackCoroutine = null;
        }
    }
}
