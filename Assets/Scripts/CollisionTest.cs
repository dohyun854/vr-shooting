using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Bullet"))
        {
         Debug.Log("피격!"); // 디버그 메시지 출력
            // 총알 파괴
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    
    }
}
