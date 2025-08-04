using UnityEngine;

public class AppleController : MonoBehaviour
{
    public float moveForce = 10f;
    public float jumpForce = 5f;
    private Rigidbody rb;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // --- 이동 ---
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(h, 0, v);
        rb.AddForce(moveDir * moveForce);

    
    }

    // 바닥에 닿았을 때만 점프 가능
    void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts.Length > 0 && collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
