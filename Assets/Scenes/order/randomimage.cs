using UnityEngine;
using UnityEngine.UI;

public class RandomImageDisplay : MonoBehaviour
{
    public Image targetImage;        // 이미지를 표시할 UI Image 오브젝트
    public Sprite image1;            // 첫 번째 이미지
    public Sprite image2;            // 두 번째 이미지

    void Start()
    {
        int randomIndex = Random.Range(0, 2); // 0 또는 1 중 하나 무작위 선택

        if (randomIndex == 0)
        {
            targetImage.sprite = image1;
        }
        else
        {
            targetImage.sprite = image2;
        }
    }
}
