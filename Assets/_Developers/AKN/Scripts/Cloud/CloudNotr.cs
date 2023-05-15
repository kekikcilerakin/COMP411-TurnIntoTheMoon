using UnityEngine;

public class CloudNotr : MonoBehaviour
{
    [SerializeField] bool hasFood;
    public CapsuleCollider2D bottomCollider;

    private void Start()
    {
        bottomCollider = GetComponentInChildren<CapsuleCollider2D>();
        bottomCollider.enabled = false;
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bottomCollider.enabled = true;
            PlayModeManager.Instance.PlayerController.IsGrounded = true;
        }
    }

    public virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bottomCollider.enabled = false;
            PlayModeManager.Instance.PlayerController.IsGrounded = false;
        }
    }
}
