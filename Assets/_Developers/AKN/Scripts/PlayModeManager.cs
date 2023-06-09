using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayModeManager : MonoBehaviour
{
    public static PlayModeManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public PlayerController PlayerController;

    public float PlaySpeed = 2.0f;
    public int energyCloudFloatSeconds = 5;

    public int score = 0;
    public int finalScore = 0;
    public int highScore = 0;

    public int requiredClouds = 0;
    public int requiredCloudsLevel1 = 10;
    public int requiredCloudsLevel2 = 20;
    public int requiredCloudsLevel3 = 30;

    public int currentClouds = 0;

    public TMP_Text scoreText;
    public TMP_Text cloudsText;
    public TMP_Text finalScoreText;
    public TMP_Text deathFinalScoreText;
    public TMP_Text highScoreText;

    public GameObject nextLevelCanvas;
    public GameObject pauseCanvas;
    public GameObject quitConfirmPanel;
    public GameObject deathCanvas;
    public GameObject allCanvas;
    public GameObject endAnim;


    public AudioClip nextLevelSound;
    public AudioClip levelFailSound;

    private void Start()
    {
        Time.timeScale = 1.0f;

        if (SceneManager.GetActiveScene().name == "LevelOne")
        {
            requiredClouds = requiredCloudsLevel1;
        }
        else if (SceneManager.GetActiveScene().name == "LevelTwo")
        {
            requiredClouds = requiredCloudsLevel2;
        }
        else if (SceneManager.GetActiveScene().name == "LevelThree")
        {
            requiredClouds = requiredCloudsLevel3;
        }

        highScore = HighScoreHolder.Instance.HighScore;
    }

    private void Update()
    {
        if (scoreText != null)
            scoreText.text = score.ToString();

        if (cloudsText != null)
            cloudsText.text = currentClouds.ToString();

        if (currentClouds == requiredClouds)
        {
            NextLevel();
        }
    }

    public void Death()
    {
        deathCanvas.SetActive(true);
        Time.timeScale = 0;
        finalScore = score * 100;
        deathFinalScoreText.text = finalScore.ToString();

        if (finalScore > highScore)
        {
            highScore = finalScore;
            HighScoreHolder.Instance.HighScore = highScore;
        }
        highScoreText.text = highScore.ToString();

        AudioSource.PlayClipAtPoint(levelFailSound, transform.position);
    }

    public void NextLevel()
    {
        

        if (SceneManager.GetActiveScene().name == "LevelThree")
        {
            EndGameAnimation();
        }
        else
        {
            if (nextLevelCanvas == null) return;

            nextLevelCanvas.SetActive(true);
            Time.timeScale = 0;
            finalScore = score * 100;
            finalScoreText.text = finalScore.ToString();

            if (finalScore > highScore)
            {
                highScore = finalScore;
                HighScoreHolder.Instance.HighScore = highScore;
            }

            AudioSource.PlayClipAtPoint(nextLevelSound, PlayerController.transform.position);
            Debug.Log("123");
        }

        currentClouds = currentClouds+1;

    }

    public void Level1ButtonClicked()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void Level2ButtonClicked()
    {
        SceneManager.LoadScene("LevelTwo");
        HighScoreHolder.Instance.LevelTwoUnlocked = true;
    }

    public void Level3ButtonClicked()
    {
        Debug.Log("3");
        SceneManager.LoadScene("LevelThree");
        HighScoreHolder.Instance.LevelThreeUnlocked = true;

    }

    public void EndGameAnimation()
    {
        PlayerController.EndGame();
    }

    public void PauseButtonClicked()
    {
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
            pauseCanvas.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseCanvas.SetActive(false);
        }
    }

    public void QuitButtonClicked()
    {
        QuitConfirmClicked();
    }

    public void QuitConfirmClicked()
    {
        pauseCanvas.SetActive(false);
        quitConfirmPanel.SetActive(true);
    }

    public void QuitYesClicked()
    {
        SceneManager.LoadScene("MenuScene");
        MenuManager.Instance.menuCanvas.SetActive(true);
    }

    public void QuitNoClicked()
    {
        pauseCanvas.SetActive(true);
        quitConfirmPanel.SetActive(false);
    }

    public void RestartLevel1Clicked()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void RestartLevel2Clicked()
    {
        SceneManager.LoadScene("LevelTwo");
    }

    public void RestartLevel3Clicked()
    {
        SceneManager.LoadScene("LevelThree");
    }
}
