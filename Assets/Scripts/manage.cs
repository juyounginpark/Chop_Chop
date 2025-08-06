using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> Players;
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
    }

    public void SwitchToNextPlayer()
    {
        Players[currentPlayerIndex].SetActive(false);
        Players[currentPlayerIndex].tag = "Untagged"; // 태그 제거

        currentPlayerIndex = (currentPlayerIndex + 1) % Players.Count;

        Players[currentPlayerIndex].SetActive(true);
        Players[currentPlayerIndex].tag = "Player"; // 태그 지정

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
}
