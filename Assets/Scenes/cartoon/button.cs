using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ComicManager : MonoBehaviour
{
    public GameObject[] comicPanels;
    public Button prevButton;
    public Button nextButton;
    public TextMeshProUGUI nextButtonText;

    private int currentIndex = 0;

    void Start()
    {
        for (int i = 0; i < comicPanels.Length; i++)
            comicPanels[i].SetActive(i == 0);

        UpdateButtons();

        prevButton.onClick.AddListener(OnPrev);
        nextButton.onClick.AddListener(OnNext);
    }

    void OnPrev()
    {
        if (currentIndex > 0)
        {
            comicPanels[currentIndex].SetActive(false); 
            currentIndex--;
            UpdateButtons();
        }
    }

    void OnNext()
    {
        if (currentIndex < comicPanels.Length - 1)
        {
            currentIndex++;
            comicPanels[currentIndex].SetActive(true); 
            UpdateButtons();
        }
        else
            gameObject.SetActive(false); 
    }

    void UpdateButtons()
    {
        prevButton.interactable = currentIndex > 0;

        if (currentIndex == comicPanels.Length - 1)
            nextButtonText.text = "Close";
        else
            nextButtonText.text = "Next";
    }
}
