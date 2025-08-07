using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{
    public Slider progressBar;
    public float fillDuration = 10f; // 총 10초 동안 채움

    private float timer = 0f;
    private bool isFilling = true;

    void Start()
    {
        if (progressBar != null)
            progressBar.value = 0f;
    }

    void Update()
    {
        if (!isFilling || progressBar == null) return;

        timer += Time.deltaTime;
        progressBar.value = Mathf.Clamp01(timer / fillDuration);

        if (progressBar.value >= 1f)
            isFilling = false; // 다 찼으면 멈춤
    }
}
