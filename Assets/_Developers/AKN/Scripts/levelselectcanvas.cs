using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelselectcanvas : MonoBehaviour
{
    public static levelselectcanvas Instance;

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

        gameObject.SetActive(false);
    }
}
