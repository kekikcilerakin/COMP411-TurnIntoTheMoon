using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    public bool IsGrounded = false;
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
    }

    private void HandleMovement()
    {
        transform.position += transform.right * Time.deltaTime * PlayModeManager.Instance.PlaySpeed;
    }

    private void HandleJump()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded)
            {
                rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
                animator.SetTrigger("Jump");
            }
        }
    }
}