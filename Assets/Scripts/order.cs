using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CustomerOrderManager : MonoBehaviour
{
    [Header("UI References")]
    public GameObject orderPanel;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI orderText;
    public Button startButton;
    public TextMeshProUGUI dayText;

    [Header("Game State")]
    public static int currentDay = 1;

    private bool orderShown = false;
    private bool isFirstTime => PlayerPrefs.GetInt("HasSeenTutorial", 0) == 0;

    private string[] dialogueLines = {
        "Excuse me, \nI'm gonna order!",
        "You're busy today~",
        "Here's my order!",
    };

    private string[] orderLines = {
        "Egg fry",
        "Mushroom bulgogi"
    };

    private string selectedOrder;

    void Start()
    {
        orderPanel.SetActive(false);
        orderShown = false;

        dayText.text = $"<Day {currentDay}>";
        dialogueText.text = dialogueLines[Random.Range(0, dialogueLines.Length)];

        int availableRecipes = Mathf.Clamp(currentDay, 1, orderLines.Length);
        selectedOrder = orderLines[Random.Range(0, availableRecipes)];
        orderText.text = selectedOrder;

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
    public void ResetTutorialFlag()
    {
        PlayerPrefs.DeleteKey("HasSeenTutorial");
        PlayerPrefs.Save();
    }
    void OnStartClicked()
    {
        Debug.Log($"Day {currentDay} 시작!");

        if (isFirstTime)
        {
            // 튜토리얼을 본 것으로 표시
            PlayerPrefs.SetInt("HasSeenTutorial", 1);
            PlayerPrefs.Save();

            // 튜토리얼 씬으로 이동
            SceneManager.LoadScene("tutorial");
        }
        else
        {
            // 주문에 따라 해당 씬으로 이동
            string sceneName = GetSceneNameForOrder(selectedOrder);
            SceneManager.LoadScene(sceneName);
        }
    }

    string GetSceneNameForOrder(string order)
    {
        switch (order)
        {
            case "Egg fry":
                return "eggfry";
            case "Mushroom bulgogi":
                return "ingame";
            default:
                return "DefaultScene";
        }
    }

   
}
