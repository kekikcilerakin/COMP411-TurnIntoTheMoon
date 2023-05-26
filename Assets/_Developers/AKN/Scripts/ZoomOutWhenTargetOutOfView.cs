using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class ZoomOutWhenTargetOutOfView : MonoBehaviour
{
    public Transform target; // The target object you want to follow
    public float zoomOutSpeed = 1f; // The speed at which the camera zooms out
    public float zoomOutMultiplier = 1.2f; // The multiplier applied to the camera's orthographic size when zooming out

    private CinemachineVirtualCamera virtualCamera;
    private CinemachineFramingTransposer framingTransposer;

    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        framingTransposer = virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
    }

    private void LateUpdate()
    {
        if (target == null) return;

        // Get the target's position on screen
        Vector3 targetScreenPosition = Camera.main.WorldToViewportPoint(target.position);

        // If the target is outside the screen, zoom out
        if (targetScreenPosition.x < 0 || targetScreenPosition.x > 1 ||
            targetScreenPosition.y < 0 || targetScreenPosition.y > 1)
        {
            framingTransposer.m_CameraDistance -= zoomOutSpeed * Time.deltaTime;
            virtualCamera.m_Lens.OrthographicSize *= zoomOutMultiplier;
        }
    }
}
