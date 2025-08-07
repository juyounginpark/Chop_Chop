using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomerOrderManager : MonoBehaviour
{
    [Header("UI References")]
    public GameObject orderPanel;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI orderText;
    public Button startButton;
    public TextMeshProUGUI dayText;

    [Header("Game State")]
    public int currentDay = 1; // 외부에서 증가 가능

    private bool orderShown = false;

    private string[] dialogueLines = {
        "Excuse me, \nI'm gonna order!",
        "You're busy today~",
        "Here's my order!",
    };

    private string[] orderLines = {
        "Egg fry",
        "Just cool soy sauce.",
        "Sliced tomato",
        "Meatball",
        "Tomato soup",
        "Mushroom bulgogi"
    };

    void Start()
    {
        orderPanel.SetActive(false);
        orderShown = false;

        dayText.text = $"<Day {currentDay}>";

        // 손님 대사 무작위 선택
        dialogueText.text = dialogueLines[Random.Range(0, dialogueLines.Length)];

        // 현재 Day에 따라 레시피 수 제한
        int availableRecipes = Mathf.Clamp(currentDay * 3, 1, orderLines.Length);
        string order = orderLines[Random.Range(0, availableRecipes)];
        orderText.text = order;

        startButton.onClick.AddListener(OnStartClicked);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !orderShown)
        {
            ShowOrderPanel();
        }
    }

    void ShowOrderPanel()
    {
        orderPanel.SetActive(true);
        orderShown = true;
    }

    void OnStartClicked()
    {
        Debug.Log($"Day {currentDay} 시작!");
        // 게임 시작 로직 또는 다음 씬 로드
    }
}
