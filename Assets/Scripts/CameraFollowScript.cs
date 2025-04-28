using Unity.VisualScripting;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    // camera stick position
    [Header("Camera Lock Position")]
    public float yCamera = 0;
    public float xCamera = 3;

    // used to control zoom
    [Header("Camera Zoom")]
    private float zoomCurrent;
    public float zoomIn = 5;
    public float zoomOut = 12;

    // camera bounds, set xMax according of the length of the level
    [Header("Camera bounds")]
    public float xMin = -5;
    public float xMax = 0;

    // player object to follow
    [Header("Target Game Object")]
    public Transform target;

    void Update()
    {

        // get current zoom size
        zoomCurrent = Camera.main.orthographicSize;

        handleFollow();
        handleZoom(0.1f);
    }

    private void handleFollow()
    {
        // check if player is inside the camera follow bounds
        if (target.position.x > xMin && target.position.x < xMax)
        {
            // update camera x position
            transform.position = new Vector3(xCamera + target.position.x, yCamera, -5);
        }
    }

    private void handleZoom(float zoomStep)
    {
        // check if player is above 3rd layer -> handle zoom out
        if (target.position.y > 3 && zoomCurrent - zoomStep < zoomOut)
        {
            Camera.main.orthographicSize = zoomCurrent + zoomStep;
        }

        // check if player is below 3rd layer -> handle zoom in
        if (target.position.y < 3 && zoomCurrent > zoomIn)
        {
            Camera.main.orthographicSize = zoomCurrent - zoomStep;
        }
    }
}
