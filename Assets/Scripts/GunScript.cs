using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunScript : MonoBehaviour
{
    public GameObject bulletPrefab; // 총알 프리팹
    public Transform firePoint;     // 총구 위치
    public float bulletSpeed = 20f; // 총알 속도

    private InputAction fireAction; // Fire 액션

    private void OnEnable()
    {
        // Fire 액션 활성화
        fireAction = new InputAction(type: InputActionType.Button, binding: "<XRController>{RightHand}/triggerPressed");
        fireAction.performed += _ => Shoot();
        fireAction.Enable();
    }

    private void OnDisable()
    {
        // Fire 액션 비활성화
        fireAction.Disable();
    }

    private void Shoot()
    {
        // 총알 생성 및 발사
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePoint.forward * bulletSpeed;
        }
    }
}