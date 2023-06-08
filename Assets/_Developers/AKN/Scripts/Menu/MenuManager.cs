using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menuCanvas;
    [SerializeField] private GameObject levelSelectCanvas;
    [SerializeField] private GameObject tutorialCanvas;
    [SerializeField] private GameObject storePanel;

    public static MenuManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else if (this != Instance)
        {
            Destroy(gameObject);
        }
    }
    public void PlayButtonClicked()
    {
        menuCanvas.SetActive(false);
        levelSelectCanvas.SetActive(true);
        storePanel.SetActive(false);
    }
    public void BackButtonClicked()
    {
        menuCanvas.SetActive(true);
        levelSelectCanvas.SetActive(false);
    }
    public void StoreButtonClicked()
    {
        storePanel.SetActive(!storePanel.activeSelf);
    }

    public void Level1ButtonClicked()
    {
        SceneManager.LoadScene("LevelOne");
        storePanel.SetActive(false);
        menuCanvas.SetActive(false);
        levelSelectCanvas.SetActive(false);
    }

    public void Level2ButtonClicked()
    {
        if (HighScoreHolder.Instance.LevelTwoUnlocked)
        {
            SceneManager.LoadScene("LevelTwo");
            storePanel.SetActive(false);
            menuCanvas.SetActive(false);
            levelSelectCanvas.SetActive(false);
        }
    }

    public void Level3ButtonClicked()
    {
        if (HighScoreHolder.Instance.LevelThreeUnlocked)
        {
            SceneManager.LoadScene("LevelThree");
            storePanel.SetActive(false);
            menuCanvas.SetActive(false);
            levelSelectCanvas.SetActive(false);
        }
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
