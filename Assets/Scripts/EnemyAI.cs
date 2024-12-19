using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public Transform player;
    private Animator animator;

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
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            if (animator != null)
            {
                animator.SetFloat("Speed", speed);
            }
        }
        else
        {
            Debug.LogError("Player object not set.");
        }
    }
}
