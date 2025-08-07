using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleclearSceneManager : MonoBehaviour
{
    public void LoadGame()
    {
        SceneLoader.sceneToLoad = "Day"; // 다음 씬 지정
        SceneManager.LoadScene("loading"); // 로딩씬으로 이동
    }
} 