using UnityEngine;

public class CatAnimationSceneOneScript : MonoBehaviour
{
    public float jumpForce = 8f;
    public float moveSpeed = 5f;

    private GameMasterSceneOneScript gm;
    private Rigidbody2D rb;

    private bool isJumped = false;

    void Start()
    {
        gm = FindAnyObjectByType<GameMasterSceneOneScript>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (gm.getIsCatAnimation())
        {
            Debug.Log("Start cat animation");

            CatMove();
        }
    }

    private void CatMove()
    {
        rb.linearVelocityX = moveSpeed;

        if (!isJumped)
        {
            rb.AddForce(Vector2.up * jumpForce, (ForceMode2D)ForceMode.Impulse);
            isJumped = true;
        }
    }
}
