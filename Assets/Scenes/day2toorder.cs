using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class Titleday2SceneManager : MonoBehaviour
{
    public TextMeshProUGUI dayText;

    private void Start()
    {
        StartCoroutine(ShowDayAndLoadNextScene());
    }

    IEnumerator ShowDayAndLoadNextScene()
    {
        // Day 증가 및 표시
        int newDay = ++CustomerOrderManager.currentDay;
        dayText.text = $"Day {newDay}";

        // 1초 기다렸다가 씬 이동
        yield return new WaitForSecondsRealtime(4f);

        SceneLoader.sceneToLoad = "order"; // 다음 씬 이름 설정
        SceneManager.LoadScene("loading"); // 로딩 씬으로 전환
    }
}
