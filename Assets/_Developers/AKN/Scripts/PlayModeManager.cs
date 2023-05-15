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
}
