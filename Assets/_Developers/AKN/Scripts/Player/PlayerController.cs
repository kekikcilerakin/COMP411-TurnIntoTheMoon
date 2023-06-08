using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    public bool IsGrounded = false;
    public bool canMultipleJump = false;
    public int jumpCount = 0;
    [SerializeField] private float jumpAmount = 10.0f;
    [SerializeField] private Animator animator;

    public GameObject hatOne;
    public GameObject hatTwo;
    public GameObject hatThree;

    public GameObject EnergyBarPanel;
    public bool isEndgame = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();

        EnergyBarPanel.GetComponent<Slider>().maxValue = PlayModeManager.Instance.energyCloudFloatSeconds;
        EnergyBarPanel.GetComponent<Slider>().value = PlayModeManager.Instance.energyCloudFloatSeconds;

        if (HighScoreHolder.Instance.hatOneEquipped)
        {
            hatOne.SetActive(true);
            hatTwo.SetActive(false);
            hatThree.SetActive(false);
        }
        else if (HighScoreHolder.Instance.hatTwoEquipped)
        {
            hatOne.SetActive(false);
            hatTwo.SetActive(true);
            hatThree.SetActive(false);
        }
        else if (HighScoreHolder.Instance.hatThreeEquipped)
        {
            hatOne.SetActive(false);
            hatTwo.SetActive(false);
            hatThree.SetActive(true);
        }
    }
    private void Update()
    {
        if (!isEndgame)
        {
            HandleMovement();
            HandleJump();

            if (canMultipleJump)
            {
                if (jumpCount == 3)
                {
                    canMultipleJump = false;
                }
            }
        }
        
    }

    private void HandleMovement()
    {
        transform.position += transform.right * Time.deltaTime * PlayModeManager.Instance.PlaySpeed;
    }

    private void HandleJump()
    {
        if (IsGrounded || canMultipleJump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpAmount);
                animator.SetTrigger("Jump");
                jumpCount++;
            }
            else if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpAmount);
                    animator.SetTrigger("Jump");
                    jumpCount++;
                }
            }
        }
    }

    public void MakeItJump()
    {
        if (isEndgame) return;

        rb.velocity = new Vector2(rb.velocity.x, 20.0f);
        animator.SetTrigger("Jump");
        PlayModeManager.Instance.PlaySpeed = 10.0f;
        Invoke("FasterTime", 1.25f);
    }

    public void MakeItFloat(int seconds)
    {
        if (isEndgame) return;

        EnergyBarPanel.SetActive(true);
        StartCoroutine(StartCountdown(seconds));
    }

    private System.Collections.IEnumerator StartCountdown(int seconds)
    {
        float countdownDuration = seconds;
        float currentTime = countdownDuration;

        while (currentTime > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 20.0f);
            EnergyBarPanel.GetComponent<Slider>().value = currentTime;
            Debug.Log(currentTime);
            yield return new WaitForSeconds(0.3f);
            rb.bodyType = RigidbodyType2D.Static;

            currentTime--;
        }

        Debug.Log("Countdown finished!");
        rb.bodyType = RigidbodyType2D.Dynamic;
        canMultipleJump = true;
        jumpCount = 0;
        EnergyBarPanel.SetActive(false);
    }

    private void FasterTime()
    {
        PlayModeManager.Instance.PlaySpeed = 5.0f;
    }

    public void EndGame()
    {
        isEndgame = true;
        PlayModeManager.Instance.allCanvas.SetActive(false);
        
        StartCoroutine(EndGameCountdown());
    }

    private System.Collections.IEnumerator EndGameCountdown()
    {
        
        float countdownDuration = 10f;
        float currentTime = countdownDuration;

        while (currentTime > 0)
        {
            rb.velocity = new Vector2(0, 10.0f);
            yield return new WaitForSeconds(.1f);
            currentTime--;
        }

        Debug.Log("Countdown finished!");
        SceneManager.LoadScene("EndScene");

    }
}