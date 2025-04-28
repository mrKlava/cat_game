using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    // layer name of platform (any platform)
    public string oneWayPlatformLayer = "OneWayPlatform";
    // layer name of player (cat object)
    public string playerLayer = "Player";

    public Joystick joy;

    void Update()
    {
        // check if joystick is pointed down for 90%
        if (joy.Vertical < -0.9)
            {
            // allow user pass trough platform
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer(oneWayPlatformLayer), LayerMask.NameToLayer(playerLayer), true);
        } else
        {
            // user can't pass trough platform
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer(oneWayPlatformLayer), LayerMask.NameToLayer(playerLayer), false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // check if player is on platform
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Cat on platform");
        }
    }
}
