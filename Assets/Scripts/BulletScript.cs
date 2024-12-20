using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 10f; // 총알 속도
    public float lifeTime = 5f; // 총알 생존 시간

    void Start()
    {
        Destroy(gameObject, lifeTime); // 일정 시간 후 파괴
    }

    void Update()
    {
        // 총알 이동
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}