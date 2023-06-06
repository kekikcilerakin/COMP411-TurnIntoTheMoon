using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private GameObject levelSelectCanvas;
    [SerializeField] private GameObject tutorialCanvas;

    public void PlayButtonClicked()
    {
        menuCanvas.SetActive(false);
        levelSelectCanvas.SetActive(true);
    }
    public void BackButtonClicked()
    {
        menuCanvas.SetActive(true);
        levelSelectCanvas.SetActive(false);
    }

    public void Level1ButtonClicked()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void Level2ButtonClicked()
    {
        if (HighScoreHolder.Instance.LevelTwoUnlocked)
            SceneManager.LoadScene("LevelTwo");
    }

    public void Level3ButtonClicked()
    {
        if (HighScoreHolder.Instance.LevelThreeUnlocked)
            SceneManager.LoadScene("LevelThree");
    }

    private void Start()
    {
        if (HighScoreHolder.Instance.isTutorialDone)
        {
            tutorialCanvas.SetActive(false);
            menuCanvas.SetActive(true);
        }
        else
        {
            tutorialCanvas.SetActive(true);
            menuCanvas.SetActive(false);
        }
    }

    public void SkipTutorialClicked()
    {
        HighScoreHolder.Instance.isTutorialDone = true;
        tutorialCanvas.SetActive(false);
        menuCanvas.SetActive(true);
    }


}
