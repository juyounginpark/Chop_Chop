using UnityEngine;

public class FollowXZCameraWithCollision : MonoBehaviour
{
    public float fixedY = 5100f;
    public float followSpeed = 0;
    public float cameraDistance = 0;
    public float XDistance = 0;
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

        Vector3 targetXZ = new Vector3(target.position.x - XDistance, fixedY, target.position.z);

        Vector3 backDir = -transform.forward;
        backDir.y = 0f;
        backDir.Normalize();

        Vector3 desiredPos = targetXZ + backDir * cameraDistance;

        if (Physics.Linecast(targetXZ, desiredPos, out RaycastHit hit, collisionMask))
        {
            desiredPos = hit.point + hit.normal * 5f;
            desiredPos.y = fixedY;
        }

        transform.position = Vector3.SmoothDamp(transform.position, desiredPos, ref currentVelocity, 1f / followSpeed);
        transform.rotation = Quaternion.Euler(80f, 0f, 0f);
    }

    
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
