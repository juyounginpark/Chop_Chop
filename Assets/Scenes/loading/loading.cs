using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    public Slider loadingBar;
    public static string sceneToLoad; // 외부에서 설정

    void Start()
    {
         if (string.IsNullOrEmpty(sceneToLoad))
    {
        Debug.LogError("sceneToLoad is null or empty!");
        return;
    }
        StartCoroutine(LoadSceneAsync(sceneToLoad));
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
     Debug.Log($"Trying to load scene: {sceneName}");
    AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
    operation.allowSceneActivation = false;

    while (!operation.isDone)
    {
        float progress = Mathf.Clamp01(operation.progress / 0.9f);
        loadingBar.value = progress;
        Debug.Log($"Loading progress: {progress}");
        // 조건 한 번만 실행되도록 수정
        if (operation.progress >= 0.9f)
        {
            Debug.Log("Scene almost ready. Activating...");
            loadingBar.value = 1f;
            yield return new WaitForSeconds(1f);
            operation.allowSceneActivation = true;
        }

        yield return null;
    }
}
}