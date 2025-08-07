using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // 씬 전환을 위해 추가

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

    bool isLastPage = index == tutorialPages.Length - 1;
    closeButton.gameObject.SetActive(isLastPage);
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
        Debug.Log("튜토리얼 종료 후 다음 씬으로 이동");

        // 원하는 씬 이름으로 변경하세요!
        string nextSceneName = "eggfry"; 

        SceneManager.LoadScene(nextSceneName);
    }
}
