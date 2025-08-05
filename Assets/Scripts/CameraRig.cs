using UnityEngine;
using UnityEngine.InputSystem;

public class CameraTPS : MonoBehaviour
{
    public enum CameraDirection { FORWARD, LEFT, RIGHT, BACK }
    public static CameraDirection mDirection;

    [SerializeField] private Transform mCameraStand;
    [SerializeField] private float mCameraWidth;
    [SerializeField] private float mCameraHeight;
    [SerializeField] private float mCameraFixDist = 1.0f;
    [SerializeField] private float mLowestRot;
    [SerializeField] private float mHighestRot;

    private float mCameraDist;
    private Vector3 mDirectionForArmToCam;
    private Vector3 mRayTarget;
    private RaycastHit mHitInfo;

    private Vector2 lookInput;

    // Input System 연결 함수
    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

    void Start()
    {
        mCameraDist = Mathf.Sqrt(mCameraWidth * mCameraWidth + mCameraHeight * mCameraHeight);
        mDirectionForArmToCam = new Vector3(0, mCameraHeight, mCameraWidth).normalized;
    }

    void Update()
    {
        LookAround();
        CameraMove();
    }

    private void CameraMove()
    {
        mCameraStand.transform.position = transform.position;

        mRayTarget = mCameraStand.transform.up * mCameraHeight +
                     mCameraStand.transform.forward * mCameraWidth;

        Physics.Raycast(mCameraStand.transform.position, mRayTarget, out mHitInfo, mCameraDist);

        if (mHitInfo.point != Vector3.zero && mHitInfo.transform.CompareTag("Untagged"))
        {
            mCameraStand.transform.position = mHitInfo.point;
            mCameraStand.transform.Translate(mDirectionForArmToCam * -1 * mCameraFixDist);
        }
        else
        {
            mCameraStand.transform.localPosition = Vector3.zero;
            mCameraStand.transform.Translate(mDirectionForArmToCam * mCameraDist);
            mCameraStand.transform.Translate(mDirectionForArmToCam * -1 * mCameraFixDist);
        }
    }

    private void LookAround()
    {
        Vector3 camAngle = mCameraStand.transform.rotation.eulerAngles;
        float x = camAngle.x - lookInput.y;

        if (x < 180f)
            x = Mathf.Clamp(x, -1f, mHighestRot);
        else
            x = Mathf.Clamp(x, 360 - mLowestRot, 360);

        mCameraStand.transform.rotation = Quaternion.Euler(x, camAngle.y + lookInput.x, camAngle.z);
    }

    private void CheckDirection()
    {
        float yAngle = mCameraStand.transform.rotation.eulerAngles.y;
        if ((yAngle >= 0 && yAngle < 45) || (yAngle > 315 && yAngle < 360))
            mDirection = CameraDirection.FORWARD;
        else if (yAngle > 45 && yAngle < 135)
            mDirection = CameraDirection.RIGHT;
        else if (yAngle > 135 && yAngle < 225)
            mDirection = CameraDirection.BACK;
        else
            mDirection = CameraDirection.LEFT;
    }
}
