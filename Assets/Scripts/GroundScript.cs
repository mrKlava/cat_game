using UnityEngine;

public class GroundScript : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Cat")
        {
            Debug.Log("Cat on the Ground");
        }
    }
}
