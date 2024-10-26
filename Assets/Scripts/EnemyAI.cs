using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public Transform player;

    private void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
        else
        {
            Debug.LogError("Player object not set.");
        }
    }
}
