using UnityEngine;

public class MoveRight : MonoBehaviour
{
    private void LateUpdate()
    {
        transform.position += transform.right * Time.deltaTime * PlayModeManager.Instance.PlaySpeed;
    }
}
