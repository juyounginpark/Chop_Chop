using UnityEngine;
using UnityEngine.UI;

public class Bigsquare : MonoBehaviour
{
    public GameObject[] tutorialPages;
    public Button nextButton;
    public Button prevButton;
    public Button closeButton;

    private int currentPageIndex = 0;
    private bool reachedLastPage = false; 

    void Start()
    {
        ShowPage(currentPageIndex);

        nextButton.onClick.AddListener(NextPage);
        prevButton.onClick.AddListener(PrevPage);
        closeButton.onClick.AddListener(CloseTutor);
    }

    void ShowPage(int index)
    {
        for (int i = 0; i < tutorialPages.Length; i++)
            tutorialPages[i].SetActive(i == index);

        prevButton.interactable = index > 0;
        nextButton.interactable = index < tutorialPages.Length - 1;

        if (index == tutorialPages.Length - 1)
            reachedLastPage = true;
            
        closeButton.gameObject.SetActive(reachedLastPage);
    }

    void NextPage()
    {
        if (currentPageIndex < tutorialPages.Length - 1)
        {
            currentPageIndex++;
            ShowPage(currentPageIndex);
        }
    }

    void PrevPage()
    {
        if (currentPageIndex > 0)
        {
            currentPageIndex--;
            ShowPage(currentPageIndex);
        }
    }

    void CloseTutor()
    {
        this.gameObject.SetActive(false);
    }
}
