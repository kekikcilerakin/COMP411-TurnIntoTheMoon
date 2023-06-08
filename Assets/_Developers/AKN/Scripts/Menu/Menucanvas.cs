using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menucanvas : MonoBehaviour
{
    public static Menucanvas Instance;

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
}
