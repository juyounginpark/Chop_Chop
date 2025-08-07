using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    public Slider loadingBar;
    public static string sceneToLoad;

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

            if (operation.progress >= 0.9f)
            {
                Debug.Log("Scene almost ready. Activating...");

                loadingBar.value = 1f;
                Debug.Log(1);
                Time.timeScale = 1f;
                yield return new WaitForSecondsRealtime(1f);
                Debug.Log(2);
                operation.allowSceneActivation = true;
                Debug.Log(3);
            }

            yield return null;
         }
    }
}