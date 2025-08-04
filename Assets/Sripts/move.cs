using UnityEngine;
using UnityEngine.InputSystem;

public class AppleController : MonoBehaviour
{
    public float moveForce = 10f;
    public float jumpForce = 5f;
    public Transform cam;

    private Rigidbody rb;
    private float jumpCooldown = 10f;
    private float lastJumpTime = -10f; // 시작 시 바로 점프 가능

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (cam == null)
            cam = Camera.main.transform;
    }

    void FixedUpdate()
    {
        // --- 이동 처리 ---
        float h = 0f;
        float v = 0f;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed) v += 1;
            if (Keyboard.current.sKey.isPressed) v -= 1;
            if (Keyboard.current.dKey.isPressed) h += 1;
            if (Keyboard.current.aKey.isPressed) h -= 1;
        }

        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;
        camForward.y = 0f;
        camRight.y = 0f;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDir = (camForward * v + camRight * h).normalized;
        rb.AddForce(moveDir * moveForce);

        // --- 점프 처리 (10초 쿨다운) ---
        if (Keyboard.current.spaceKey.wasPressedThisFrame && Time.time - lastJumpTime >= jumpCooldown)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            lastJumpTime = Time.time;
        }
    }
}
