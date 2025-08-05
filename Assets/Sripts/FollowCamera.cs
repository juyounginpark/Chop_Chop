using UnityEngine;

public class FollowXZCameraWithCollision : MonoBehaviour
{
    public float fixedY = 5100f;
    public float followSpeed = 5f;
    public float cameraDistance = 1000f;
    public float XDistance = 200f;
    public LayerMask collisionMask;

    private Transform target;
    private Vector3 currentVelocity;

    void Start()
    {
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
            target = playerObj.transform;
        else
            Debug.LogWarning("Player 태그를 가진 오브젝트를 찾을 수 없습니다.");
    }

    void LateUpdate()
    {
        if (target == null) return;

        // 타겟 위치 보정 (X축으로 offset 주고 Y는 고정)
        Vector3 targetXZ = new Vector3(target.position.x - XDistance, fixedY, target.position.z);

        // 카메라의 뒤쪽 방향 (XZ 평면)
        Vector3 backDir = -transform.forward;
        backDir.y = 0f;
        backDir.Normalize();

        // 원하는 위치 계산
        Vector3 desiredPos = targetXZ + backDir * cameraDistance;

        // 충돌 감지
        if (Physics.Linecast(targetXZ, desiredPos, out RaycastHit hit, collisionMask))
        {
            desiredPos = hit.point + hit.normal * 5f;
            desiredPos.y = fixedY;
        }

        // 부드러운 이동
        transform.position = Vector3.SmoothDamp(transform.position, desiredPos, ref currentVelocity, 1f / followSpeed);

        // 고정된 회전
        transform.rotation = Quaternion.Euler(80f, 0f, 0f);
    }
}
