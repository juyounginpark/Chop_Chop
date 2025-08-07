using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScenemainManager : MonoBehaviour
{
    public void LoadGame()
    {
        SceneLoader.sceneToLoad = "cartoon"; // 다음 씬 지정
        SceneManager.LoadScene("loading"); // 로딩씬으로 이동
    }
}
