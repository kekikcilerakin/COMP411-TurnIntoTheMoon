using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreHolder : MonoBehaviour
{
    public static HighScoreHolder Instance;

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

    public int HighScore = 0;
    public bool LevelOneUnlocked = true;
    public bool LevelTwoUnlocked = false;
    public bool LevelThreeUnlocked = false;

    public bool isTutorialDone = false;
}
