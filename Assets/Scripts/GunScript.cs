using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunScript : MonoBehaviour
{
    public GameObject bulletPrefab; // 총알 프리팹
    public Transform firePoint;     // 총구 위치
    public float bulletSpeed = 20f; // 총알 속도
    public AudioClip shootingSound; // 총 발사 소리

    private AudioSource audioSource;
    private InputAction fireActionRight;
    private InputAction fireActionLeft;

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = shootingSound;
    }

    private void OnEnable()
    {
        fireActionRight = new InputAction(type: InputActionType.Button, binding: "<XRController>{RightHand}/triggerPressed");
        fireActionRight.performed += _ => Shoot();
        fireActionRight.Enable();

        fireActionLeft = new InputAction(type: InputActionType.Button, binding: "<XRController>{LeftHand}/triggerPressed");
        fireActionLeft.performed += _ => Shoot();
        fireActionLeft.Enable();
    }

    private void OnDisable()
    {
        fireActionRight.Disable();
        fireActionLeft.Disable();
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePoint.forward * bulletSpeed;
        }
        
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
