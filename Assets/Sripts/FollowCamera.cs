using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;        // 사과 오브젝트
    public Vector3 offset = new Vector3(0, 5, -5);  // 높이 5, 뒤로 5
    public float followSpeed = 5f;

    void LateUpdate()
    {
        if (target == null) return;

        // 사과 위치 기준으로 카메라 위치 설정
        Vector3 desiredPosition = target.position + offset;

        // 부드럽게 따라가기
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        // 항상 사과를 바라보게
        transform.LookAt(target);
    }
}
