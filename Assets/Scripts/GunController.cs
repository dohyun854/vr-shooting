using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    // 손 Transform (VR 컨트롤러의 위치)
    public Transform rightHandTransform;  // 오른손 Transform
    public Transform leftHandTransform;   // 왼손 Transform

    // 총의 구성 요소
    public Transform gunCenter;           // 총의 중앙 축
    public Transform rightGrip;           // 오른손 손잡이 (총 프리팹 내부)
    public Transform leftGrip;            // 왼손 손잡이 (총 프리팹 내부)

    private void Start()
    {
        // 플레이어 손 비활성화 (손 모델이 보이지 않도록)
        if (rightHandTransform.gameObject.activeSelf)
            rightHandTransform.gameObject.SetActive(false);
        if (leftHandTransform.gameObject.activeSelf)
            leftHandTransform.gameObject.SetActive(false);
    }

    private void Update()
    {
        // 손잡이를 손 위치로 이동
        MoveGripsToHand();

        // 손잡이에 따라 총 전체를 움직이고 회전
        UpdateGunPositionAndRotation();
    }

    // 손잡이를 손 위치로 이동
    private void MoveGripsToHand()
    {
        if (rightHandTransform != null && rightGrip != null)
        {
            rightGrip.position = rightHandTransform.position;
        }
        if (leftHandTransform != null && leftGrip != null)
        {
            leftGrip.position = leftHandTransform.position;
        }
    }

    // 손잡이 위치를 바탕으로 총 위치와 회전을 업데이트
    private void UpdateGunPositionAndRotation()
    {
        if (rightGrip != null && leftGrip != null && gunCenter != null)
        {
            // 두 손잡이의 중간 지점을 계산
            Vector3 middlePoint = (rightGrip.position + leftGrip.position) / 2;

            // 중앙 축의 위치를 중간 지점으로 설정
            gunCenter.position = middlePoint;

            // 두 손잡이의 방향에 따라 총의 회전 설정
            Vector3 direction = rightGrip.position - leftGrip.position;
            gunCenter.rotation = Quaternion.LookRotation(direction);
        }
    }
}