using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Titleday2charManager : MonoBehaviour
{
    public TextMeshProUGUI dayText;

    public void LoadGame()
    {
        // 1. Day 값을 1 증가시키고
        int newDay = ++CustomerOrderManager.currentDay;
        dayText.text = $"Day {newDay}";
    }
}
