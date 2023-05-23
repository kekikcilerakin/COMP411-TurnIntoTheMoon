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

    public int score = 0;

    public int requiredClouds = 10;
    public int currentClouds = 0;

    public TMP_Text scoreText;
    public TMP_Text cloudsText;

    public GameObject nextLevelCanvas;

    private void Start()
    {
        Time.timeScale = 1.0f;
    }

    private void Update()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;

        if (cloudsText != null)
            cloudsText.text = "Clouds: " + currentClouds + "/" + requiredClouds;

        if (currentClouds == requiredClouds)
        {
            NextLevel();
        }
    }

    public void NextLevel()
    {
        nextLevelCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void Level1ButtonClicked()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void Level2ButtonClicked()
    {
        SceneManager.LoadScene("LevelTwo");
    }

    public void Level3ButtonClicked()
    {
        SceneManager.LoadScene("LevelThree");
    }
}
