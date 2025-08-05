using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> Players;
    private int currentPlayerIndex = 0;

    private void Start()
    {
        for (int i = 0; i < Players.Count; i++)
            Players[i].SetActive(i == currentPlayerIndex);

        // 카메라 초기 타겟 설정
        FollowXZCameraWithCollision cam = Camera.main.GetComponent<FollowXZCameraWithCollision>();
        if (cam != null)
            cam.SetTarget(Players[currentPlayerIndex].transform);
    }

    public void SwitchToNextPlayer()
    {
        Players[currentPlayerIndex].SetActive(false);

        currentPlayerIndex++;
        if (currentPlayerIndex >= Players.Count)
            currentPlayerIndex = 0;

        Players[currentPlayerIndex].SetActive(true);

        FollowXZCameraWithCollision cam = Camera.main.GetComponent<FollowXZCameraWithCollision>();
        if (cam != null)
            cam.SetTarget(Players[currentPlayerIndex].transform);
    }
}
