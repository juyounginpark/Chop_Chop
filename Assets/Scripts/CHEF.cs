using UnityEngine;

public class ChefLookAtTarget : MonoBehaviour
{
    private FollowXZCameraWithCollision cam;
    public float moveSpeed = 2f; // 이동 속도

    void Start()
    {
        cam = Camera.main.GetComponent<FollowXZCameraWithCollision>();
        if (cam == null)
            Debug.LogWarning("카메라에서 FollowXZCameraWithCollision 컴포넌트를 찾을 수 없습니다.");
    }

    void Update()
    {
        if (cam == null) return;

        Transform target = cam.GetTarget();
        if (target == null) return;

        // 1. 바라보기 (y축만)
        Vector3 direction = target.position - transform.position;
        direction.y = 0f;

        if (direction.sqrMagnitude > 0.001f)
        {
            Quaternion targetRot = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * 5f);
        }

        // 2. 바라보는 방향으로 이동
        Vector3 forward = transform.forward;
        forward.y = 0f;
        transform.position += forward.normalized * moveSpeed * Time.deltaTime;
    }
}
