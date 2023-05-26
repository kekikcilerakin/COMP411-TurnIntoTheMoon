using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;     // The target object to follow
    public float smoothSpeed = 0.5f;  // The speed of camera movement
    public float minZoom = 5f;   // The minimum orthographic size (zoomed out)
    public float maxZoom = 10f;  // The maximum orthographic size (zoomed in)
    public float zoomLerpSpeed = 5f;  // The speed of camera zoom
    public Vector3 offset;       // The offset from the target position
    private Camera cam;          // Reference to the camera component

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        // Follow the target smoothly
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Calculate the distance from the target
        float distance = Vector3.Distance(target.position, transform.position);

        // Zoom the camera based on the distance
        float targetOrthographicSize = Mathf.Lerp(minZoom, maxZoom, distance / 10f);  // Adjust the divisor to control zoom sensitivity
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetOrthographicSize, Time.deltaTime * zoomLerpSpeed);
    }
}
