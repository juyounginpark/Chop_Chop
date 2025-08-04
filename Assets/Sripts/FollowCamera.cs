using UnityEngine;

public class FixedTPSCamera : MonoBehaviour
{
    public Transform target;                     // 플레이어
    public Vector3 offset = new Vector3(0f, 4f, -6f); // 고정 오프셋 (위 + 뒤)
    public float smoothSpeed = 10f;              // 따라가는 속도
    public float collisionBuffer = 0.2f;         // 충돌시 여유 거리
    private float defaultDistance;

    int collisionMask;
    private Quaternion fixedRotation;            // 고정 회전값

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("target 지정 안됨");
            enabled = false;
            return;
        }

        defaultDistance = offset.magnitude;
        collisionMask = ~LayerMask.GetMask("Player"); // Player 레이어 제외 충돌 체크

        // 처음 시작할 때 카메라 회전을 고정시켜 저장
        fixedRotation = transform.rotation;
    }

    void LateUpdate()
    {
        Vector3 direction = offset.normalized;
        Vector3 desiredPosition = target.position + offset;

        if (Physics.Raycast(target.position, direction, out RaycastHit hit, defaultDistance, collisionMask))
        {
            float hitDist = Mathf.Clamp(hit.distance - collisionBuffer, 0.5f, defaultDistance);
            Vector3 adjustedOffset = direction * hitDist;
            desiredPosition = target.position + adjustedOffset;
        }

        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);

        // 카메라 회전 고정
        transform.rotation = fixedRotation;
    }
}
