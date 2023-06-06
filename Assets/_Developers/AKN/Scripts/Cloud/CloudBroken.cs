using UnityEngine;

public class CloudBroken : CloudNotr
{
    public GameObject brokenPrefab;

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        Debug.Log("Broken");
        Instantiate(brokenPrefab, transform.position, Quaternion.identity);
        GetComponentInChildren<SpriteRenderer>().enabled = false;
        AudioSource.PlayClipAtPoint(sound, transform.position);

    }

    public override void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);

        
        Destroy(gameObject);
    }
}
