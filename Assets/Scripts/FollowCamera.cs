using UnityEngine;

public class FollowXZCameraWithCollision : MonoBehaviour
{
    public float fixedY = 5100f;
    public float followSpeed = 5f;
    public float cameraDistance = 1000f;
    public float XDistance = 0f;
    public LayerMask collisionMask;

    private Transform target;
    private Vector3 currentVelocity;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        Debug.Log("카메라 타겟 설정됨: " + newTarget.name);
    }

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

        // 타겟의 xz 평면 위치
        Vector3 targetXZ = new Vector3(target.position.x - XDistance, fixedY, target.position.z);

        // 카메라 뒤쪽 방향
        Vector3 backDir = new Vector3(0, 0, -1); // z축 뒤쪽
        Vector3 desiredPos = targetXZ + backDir * cameraDistance;

        // 충돌 처리
        if (Physics.Linecast(targetXZ, desiredPos, out RaycastHit hit, collisionMask))
        {
            desiredPos = hit.point + hit.normal * 5f;
            desiredPos.y = fixedY;
        }

        // 부드럽게 따라감
        transform.position = Vector3.SmoothDamp(transform.position, desiredPos, ref currentVelocity, 1f / followSpeed);

        // 고정된 회전 각도
        transform.rotation = Quaternion.Euler(80f, 0f, 0f);
    }
    
    public void JumpToTarget()
{
    if (target == null) return;

    Vector3 targetXZ = new Vector3(target.position.x - XDistance, fixedY, target.position.z);
    Vector3 backDir = new Vector3(0, 0, -1);
    Vector3 desiredPos = targetXZ + backDir * cameraDistance;

    if (Physics.Linecast(targetXZ, desiredPos, out RaycastHit hit, collisionMask))
    {
        desiredPos = hit.point + hit.normal * 5f;
        desiredPos.y = fixedY;
    }

    transform.position = desiredPos;
}




}
