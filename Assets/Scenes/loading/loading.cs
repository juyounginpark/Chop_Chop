using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    public Slider loadingBar; 

    void Start()
    {
        StartCoroutine(LoadSceneAsync("GameScene")); 
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadingBar.value = progress;

            if (operation.progress >= 0.9f)
            {
                yield return new WaitForSeconds(1f);
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
