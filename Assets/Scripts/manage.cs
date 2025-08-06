using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> Players;
    public GameObject gameClearUI; // 🎯 UI 패널 연결
    private int currentPlayerIndex = 0;

    private void Start()
    {
        for (int i = 0; i < Players.Count; i++)
        {
            bool isActive = (i == currentPlayerIndex);
            Players[i].SetActive(isActive);
            Players[i].tag = isActive ? "Player" : "Untagged";
        }

        FollowXZCameraWithCollision cam = Camera.main.GetComponent<FollowXZCameraWithCollision>();
        if (cam != null)
            cam.SetTarget(Players[currentPlayerIndex].transform);

        if (gameClearUI != null)
            gameClearUI.SetActive(false); // UI 꺼놓기
    }

    public void SwitchToNextPlayer()
    {
        Players[currentPlayerIndex].SetActive(false);
        Players[currentPlayerIndex].tag = "Untagged";

        currentPlayerIndex++;

        // 🎯 마지막 플레이어까지 끝났으면 클리어 처리
        if (currentPlayerIndex >= Players.Count)
        {
            GameClear();
            return;
        }

        Players[currentPlayerIndex].SetActive(true);
        Players[currentPlayerIndex].tag = "Player";

        StartCoroutine(DelayCameraFollow());
    }

    private IEnumerator DelayCameraFollow()
    {
        yield return null;

        FollowXZCameraWithCollision cam = Camera.main.GetComponent<FollowXZCameraWithCollision>();
        if (cam != null)
        {
            cam.SetTarget(Players[currentPlayerIndex].transform);
            cam.JumpToTarget();
        }
    }

    private void GameClear()
    {
        Debug.Log("게임 클리어!");
        Time.timeScale = 0f;

        if (gameClearUI != null)
            gameClearUI.SetActive(true);
    }
}
