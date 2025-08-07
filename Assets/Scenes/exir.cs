using UnityEngine;

public class GameExitManager : MonoBehaviour
{
    public void ExitGame()
    {
        Debug.Log("게임 종료 시도");

#if UNITY_EDITOR
        // 에디터에서 실행 중이면 플레이 모드 종료
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // 실제 빌드에서는 앱 종료
        Application.Quit();
#endif
    }
}