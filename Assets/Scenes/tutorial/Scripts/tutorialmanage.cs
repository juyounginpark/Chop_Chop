using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialPanel;

    public void OpenTutorial()
    {
        tutorialPanel.SetActive(true);
    }

    public void CloseTutorial()
    {
        tutorialPanel.SetActive(false);
    }
}
