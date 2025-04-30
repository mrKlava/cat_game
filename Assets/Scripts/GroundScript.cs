using UnityEngine;

public class GroundScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // check if player is on the ground
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Cat on the Ground");
        }
    }
}
