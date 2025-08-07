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
    public TextMeshProUGUI fameText;
    public TextMeshProUGUI revenueText;

    [Header("Game State")]
    public static int currentDay = 1;

    private bool orderShown = false;
    private bool isFirstTime => PlayerPrefs.GetInt("HasSeenTutorial", 0) == 0;

    private string[] dialogueLines = {
        "Excuse me, \nI'm gonna order!",
        "You're busy today~",
        "Here's my order!",
    };

    private string selectedOrder;
    private int fame = 0;
    private int revenue = 0;

    void Start()
    {
        orderPanel.SetActive(false);
        orderShown = false;

        // Set day text
        dayText.text = $"<Day {currentDay}>";

        // Set fame & revenue based on day
        fame = (currentDay - 1) * 10;
        revenue = (currentDay - 1) * 20;

        fameText.text = $"Fame: {fame:D2}";
        revenueText.text = $"Revenue: {revenue:D2}";

        // Dialogue
        dialogueText.text = dialogueLines[Random.Range(0, dialogueLines.Length)];

        // Recipe selection based on day
        if (currentDay == 1)
            selectedOrder = "Egg fry";
        else
            selectedOrder = "Mushroom bulgogi";

        orderText.text = selectedOrder;

        // Button click
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
            PlayerPrefs.SetInt("HasSeenTutorial", 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("tutorial");
        }
        else
        {
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
