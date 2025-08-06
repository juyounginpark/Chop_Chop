using UnityEngine;

public class pot : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 현재 플레이어를 비활성화
            other.gameObject.SetActive(false);

            // 다음 플레이어로 전환
            if (gameManager != null)
                gameManager.SwitchToNextPlayer();
        }
    }
}
