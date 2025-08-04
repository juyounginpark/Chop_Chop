using UnityEngine;

public class ShapeSwitcher : MonoBehaviour
{
    public GameObject[] shapes;  // 모델들 (자식 오브젝트들)
    private int currentIndex = 0;

    void Start()
    {
        ShowOnly(currentIndex);  // 시작 시 첫 번째 모양만 보이게
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentIndex = (currentIndex + 1) % shapes.Length;
            ShowOnly(currentIndex);
        }
    }

    void ShowOnly(int index)
    {
        for (int i = 0; i < shapes.Length; i++)
        {
            shapes[i].SetActive(i == index);  // index 번째만 활성화
        }
    }
}
