using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomerOrderManager : MonoBehaviour
{
    public GameObject orderPanel;          // 주문 창
    public TextMeshProUGUI dialogueText;   // 손님 대사
    public TextMeshProUGUI orderText;      
    public Button startButton;           

    private bool orderShown = false;

    void Start()
    {
        orderPanel.SetActive(false);
        dialogueText.text = "안녕하세요! 주문 좀 받을 수 있을까요?";
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
        orderText.text = "아메리카노 한 잔 주세요.";
        orderShown = true;
    }

    void OnStartClicked()
    {
        Debug.Log("게임 시작!");
    }
}
