using UnityEngine;

public class CloudEnergy : CloudNotr
{

    
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        Debug.Log("Energy");

        AudioSource.PlayClipAtPoint(sound, transform.position);

        PlayModeManager.Instance.PlayerController.MakeItFloat(PlayModeManager.Instance.energyCloudFloatSeconds);
    }

    public override void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);
    }
}
