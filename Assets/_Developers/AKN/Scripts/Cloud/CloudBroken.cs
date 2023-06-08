using UnityEngine;

public class CloudBroken : CloudNotr
{
    public GameObject brokenPrefab;

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        Debug.Log("Broken");
        Vector3 targetPos = new Vector3(transform.position.x, transform.position.y - 4.75f, transform.position.z);
        Instantiate(brokenPrefab, targetPos, Quaternion.identity);
        GetComponentInChildren<SpriteRenderer>().enabled = false;
        AudioSource.PlayClipAtPoint(sound, transform.position);

    }

    public override void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);

        Destroy(gameObject);
    }
}
