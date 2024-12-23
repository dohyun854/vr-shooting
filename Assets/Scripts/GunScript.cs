using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunScript : MonoBehaviour
{
    public GameObject bulletPrefab; // 총알 프리팹
    public Transform firePoint;     // 총구 위치
    public float bulletSpeed = 20f; // 총알 속도

    private InputAction fireActionRight; // Fire 액션
    private InputAction fireActionLeft;

   private void OnEnable()
{
    // 오른손 트리거로 총 쏘기
    fireActionRight = new InputAction(type: InputActionType.Button, binding: "<XRController>{RightHand}/triggerPressed");
    fireActionRight.performed += _ => Shoot();
    fireActionRight.Enable();

    // 왼손 트리거로 총 쏘기
    fireActionLeft = new InputAction(type: InputActionType.Button, binding: "<XRController>{LeftHand}/triggerPressed");
    fireActionLeft.performed += _ => Shoot();
    fireActionLeft.Enable();
}

private void OnDisable()
{
    // 오른손 트리거 비활성화
    fireActionRight.Disable();

    // 왼손 트리거 비활성화
    fireActionLeft.Disable();
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