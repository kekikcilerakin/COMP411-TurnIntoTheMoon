using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    public bool IsGrounded = false;
    public bool canMultipleJump = false;
    public int jumpCount = 0;
    [SerializeField] private float jumpAmount = 10.0f;
    [SerializeField] private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }
    private void Update()
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

    private void HandleMovement()
    {
        transform.position += transform.right * Time.deltaTime * PlayModeManager.Instance.PlaySpeed;
    }

    private void HandleJump()
    {
        if (IsGrounded || canMultipleJump)
        {
            if (!Input.GetKeyDown(KeyCode.Space)) return;

            rb.velocity = new Vector2(rb.velocity.x, jumpAmount);
            animator.SetTrigger("Jump");
            jumpCount++;

        }
    }

    public void MakeItJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 20.0f);
        animator.SetTrigger("Jump");
        PlayModeManager.Instance.PlaySpeed = 10.0f;
        Invoke("FasterTime", 1.25f);
    }

    public void MakeItFloat(int seconds)
    {
        StartCoroutine(StartCountdown(seconds));
    }

    private System.Collections.IEnumerator StartCountdown(int seconds)
    {
        float countdownDuration = seconds;
        float currentTime = countdownDuration;

        while (currentTime > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 20.0f);
            
            Debug.Log(currentTime);
            yield return new WaitForSeconds(0.3f);
            rb.bodyType = RigidbodyType2D.Static;

            currentTime--;
        }

        Debug.Log("Countdown finished!");
        rb.bodyType = RigidbodyType2D.Dynamic;
        canMultipleJump = true;
        jumpCount = 0;
    }

    private void FasterTime()
    {
        PlayModeManager.Instance.PlaySpeed = 5.0f;
    }
}