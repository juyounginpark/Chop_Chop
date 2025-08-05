using UnityEngine;

public class ShapeSwitcher : MonoBehaviour
{
    public GameObject[] shapes;  // 모델들 (자식 오브젝트들)
    private int currentIndex = 0;

    public string triggerTag = "Changer"; // 충돌할 대상의 태그

    void Start()
    {
        ShowOnly(currentIndex);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchToNextShape();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggerTag))
        {
            SwitchToNextShape();
        }
    }

    void SwitchToNextShape()
    {
        currentIndex = (currentIndex + 1) % shapes.Length;
        ShowOnly(currentIndex);
    }

    void ShowOnly(int index)
    {
        for (int i = 0; i < shapes.Length; i++)
        {
            shapes[i].SetActive(i == index);
        }
    }
}
