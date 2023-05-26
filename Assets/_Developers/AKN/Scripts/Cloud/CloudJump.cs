using UnityEngine;

public class CloudJump : CloudNotr
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        Debug.Log("Jump");

        PlayModeManager.Instance.PlayerController.MakeItJump();
        PlayModeManager.Instance.PlayerController.canMultipleJump = true;
        PlayModeManager.Instance.PlayerController.jumpCount = 0;

    }

    public override void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);
    }
}
