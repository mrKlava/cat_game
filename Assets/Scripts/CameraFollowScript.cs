using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    [Header("Camera Lock Position")]
    public float yCamera = 0;
    public float xCamera = 3;

    [Header("Camera bounds")]
    public float xMin = -5;
    public float xMax = 0;

    [Header("Target Game Object")]
    public Transform target;


    void Start()
    {
    
    }
    void Update()
    {
        // check if camera is in bounds
        if (target.position.x > xMin && target.position.x < xMax)
        {
            transform.position = new Vector3(xCamera + target.position.x, yCamera, -5);
        }
    }
}
