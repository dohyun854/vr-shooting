using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DirectTwoHandedWeaponController : MonoBehaviour
{


   [Header("Controller References")]
    [SerializeField] private Transform leftController;
    [SerializeField] private Transform rightController;
    
    [Header("Movement Settings")]
    [SerializeField] private float axisRotationSmoothing = 10f;
    [SerializeField] private float positionSmoothing = 15f;
    
    private Transform frontGrip;
    private Transform backGrip;
    private Vector3 frontGripLocalPosition;
    private Vector3 backGripLocalPosition;
    private Quaternion frontGripLocalRotation;
    private Quaternion backGripLocalRotation;
    
    private void Awake()
    {
        // 그립 찾기
        frontGrip = transform.Find("FrontGrip");
        backGrip = transform.Find("BackGrip");
        
        if (!ValidateComponents())
        {
            Debug.LogError($"[{gameObject.name}] 필요한 컴포넌트를 찾지 못했습니다.");
            enabled = false;
            return;
        }

        // 초기 로컬 위치와 회전 저장
        if (frontGrip != null)
        {
            frontGripLocalPosition = frontGrip.localPosition;
            frontGripLocalRotation = frontGrip.localRotation;
        }
        
        if (backGrip != null)
        {
            backGripLocalPosition = backGrip.localPosition;
            backGripLocalRotation = backGrip.localRotation;
        }
    }
    
    private bool ValidateComponents()
    {
        if (frontGrip == null)
        {
            Debug.LogError("FrontGrip을 찾을 수 없습니다.");
            return false;
        }
        if (backGrip == null)
        {
            Debug.LogError("BackGrip을 찾을 수 없습니다.");
            return false;
        }
        if (leftController == null)
        {
            Debug.LogError("왼쪽 컨트롤러 참조가 설정되지 않았습니다.");
            return false;
        }
        if (rightController == null)
        {
            Debug.LogError("오른쪽 컨트롤러 참조가 설정되지 않았습니다.");
            return false;
        }
        return true;
    }
    
    private void Update()
    {
        if (frontGrip != null && backGrip != null)
        {
            // 앞 손잡이(왼손) 업데이트
            UpdateGripPosition(frontGrip, leftController);
            
            // 뒷 손잡이(오른손) 업데이트
            UpdateGripPosition(backGrip, rightController);
        }
    }
    
    private void UpdateGripPosition(Transform gripTransform, Transform controller)
    {
        if (controller != null)
        {
            // 컨트롤러의 월드 포지션으로 그립 이동
            Vector3 targetPosition = controller.position;
            gripTransform.position = Vector3.Lerp(
                gripTransform.position, 
                targetPosition, 
                Time.deltaTime * positionSmoothing
            );
            
            // 컨트롤러의 회전 적용
            gripTransform.rotation = Quaternion.Lerp(
                gripTransform.rotation,
                controller.rotation,
                Time.deltaTime * axisRotationSmoothing
            );
        }
    }

    // 초기 위치로 리셋하는 함수 (필요한 경우 호출)
    public void ResetGripPositions()
    {
        if (frontGrip != null)
        {
            frontGrip.localPosition = frontGripLocalPosition;
            frontGrip.localRotation = frontGripLocalRotation;
        }
        
        if (backGrip != null)
        {
            backGrip.localPosition = backGripLocalPosition;
            backGrip.localRotation = backGripLocalRotation;
        }
    }
}
