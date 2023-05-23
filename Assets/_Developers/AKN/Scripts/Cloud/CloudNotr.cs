using UnityEngine;

public class CloudNotr : MonoBehaviour
{
    [SerializeField] bool hasFood;
    [SerializeField] GameObject foodPrefab;
    [SerializeField] Transform foodSpawnPoint;
    public CapsuleCollider2D bottomCollider;

    private void Start()
    {
        bottomCollider = GetComponentInChildren<CapsuleCollider2D>();
        bottomCollider.enabled = false;

        float randomNumber = Random.Range(0f, 1f);

        if (randomNumber <= 0.25f)
        {
            SpawnFood();
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bottomCollider.enabled = true;
            PlayModeManager.Instance.PlayerController.IsGrounded = true;

            if (PlayModeManager.Instance.currentClouds != PlayModeManager.Instance.requiredClouds)
            {
                PlayModeManager.Instance.currentClouds++;
            }
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

    public void SpawnFood()
    {
        hasFood = true;
        Instantiate(foodPrefab, foodSpawnPoint.position, Quaternion.identity);
    }
}
