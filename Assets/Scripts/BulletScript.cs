using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 20f;
    public float lifeTime = 5f;

    void Start()
    {
        Destroy(gameObject, lifeTime); // 총알이 일정 시간이 지나면 소멸
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // 적에게 데미지 처리
            Destroy(other.gameObject);
            Destroy(gameObject); // 총알 소멸
        }
    }
}
