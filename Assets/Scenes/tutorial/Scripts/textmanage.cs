using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialtextManager : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;
    public string[] tutorialMessages;
    private int currentIndex = 0;

    public Button prevButton;
    public Button nextButton;
    public TextMeshProUGUI nextButtonText;

    void Start()
    {
        ShowCurrentMessage();
        prevButton.onClick.AddListener(ShowPrevMessage);
        nextButton.onClick.AddListener(OnNextButtonClick);
    }

    void ShowCurrentMessage()
    {
        if (currentIndex >= 0 && currentIndex < tutorialMessages.Length)
            tutorialText.text = tutorialMessages[currentIndex];

        prevButton.interactable = currentIndex > 0;

        if (currentIndex == tutorialMessages.Length - 1)
            nextButtonText.text = "닫기";
        else
            nextButtonText.text = "다음";
    }

    public void OnNextButtonClick()
    {
        if (currentIndex < tutorialMessages.Length - 1)
        {
            currentIndex++;
            Debug.Log(currentIndex);
            ShowCurrentMessage();
        }
        else
        {
            tutorialText.gameObject.SetActive(false);
            prevButton.gameObject.SetActive(false);
            nextButton.gameObject.SetActive(false);
        }
    }

    public void ShowPrevMessage()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            ShowCurrentMessage();
        }
    }
}
