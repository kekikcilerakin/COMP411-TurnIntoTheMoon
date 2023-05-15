using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private GameObject levelSelectCanvas;

    public void PlayButtonClicked()
    {
        menuCanvas.SetActive(false);
        levelSelectCanvas.SetActive(true);
    }

    public void Level1ButtonClicked()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void Level2ButtonClicked()
    {
        //SceneManager.LoadScene("LevelTwo");
    }

    public void Level3ButtonClicked()
    {
        //SceneManager.LoadScene("LevelThree");
    }
}
