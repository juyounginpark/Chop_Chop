using System.Collections.Generic;
using UnityEngine;

public class ShapeSwitcher : MonoBehaviour
{
    public GameObject wholeObject;  // 자르기 전 모델
    public GameObject slicedObject; // 자른 후 모델

    public string objectType = "Cucumber"; // 오이, 당근, 고기 등

    private Dictionary<string, string[]> interactionMap = new Dictionary<string, string[]>
    {
        { "Cucumber", new string[] { "Knife" } },
        { "Carrot", new string[] { "Knife", "Slicer" } },
        { "Meat", new string[] { "Fire" } },
        { "Tomato", new string[] { "Knife" } }
    };

    private void Start()
    {
        if (wholeObject != null) wholeObject.SetActive(true);
        if (slicedObject != null) slicedObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (interactionMap.TryGetValue(objectType, out string[] validTools))
        {
            foreach (string tool in validTools)
            {
                if (other.CompareTag(tool))
                {
                    // 위치 및 회전 동기화
                    slicedObject.transform.position = wholeObject.transform.position;
                    slicedObject.transform.rotation = wholeObject.transform.rotation;

                    // 전환
                    wholeObject.SetActive(false);
                    slicedObject.SetActive(true);

                    // 카메라 타겟 변경
                    FollowXZCameraWithCollision cameraFollow = Camera.main.GetComponent<FollowXZCameraWithCollision>();
                    if (cameraFollow != null)
                    {
                        cameraFollow.SetTarget(slicedObject.transform);
                    }

                    Debug.Log($"{objectType} was sliced with {tool}");
                    break;
                }
            }
        }
    }
}
