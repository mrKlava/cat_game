using UnityEngine;
using UnityEngine.UI;


public class JoystickScript : MonoBehaviour
{
    private Joystick joy;

    public float x;
    public float y;

    void Start()
    {
        joy = GetComponent<Joystick>();
    }

    void Update()
    {
        x = joy.Horizontal;
        y = joy.Vertical;
    }
}
