using TMPro;
using UnityEngine;

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

    public TMP_Text tmpText;

    private void Update()
    {
        if (tmpText != null)
            tmpText.text = "Score: " + score;
    }
}
