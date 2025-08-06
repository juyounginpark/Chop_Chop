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

    public Transform GetTarget()  // ✅ 추가된 부분
    {
        return target;
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

        Vector3 targetXZ = new Vector3(target.position.x - XDistance, fixedY, target.position.z);
        Vector3 backDir = new Vector3(0, 0, -1);
        Vector3 desiredPos = targetXZ + backDir * cameraDistance;

        if (Physics.Linecast(targetXZ, desiredPos, out RaycastHit hit, collisionMask))
        {
            desiredPos = hit.point + hit.normal * 5f;
            desiredPos.y = fixedY;
        }

        transform.position = Vector3.SmoothDamp(transform.position, desiredPos, ref currentVelocity, 1f / followSpeed);
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
