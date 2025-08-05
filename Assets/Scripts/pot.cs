using UnityEngine;

public class PotTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager gm = FindObjectOfType<GameManager>();
            if (gm != null)
            {
                gm.SwitchToNextPlayer();
                Debug.Log("다음 야채로 전환");
            }
            else
            {
                Debug.Log("GameManager 없음");
            }
        }
    }
}
