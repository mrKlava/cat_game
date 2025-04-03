using UnityEngine;

public class CatAnimationHomeReturnSceneScript : MonoBehaviour
{
    public float moveSpeed = -3f;

    private GameMasterHomeReturnSceneScript gm;
    private Rigidbody2D rb;

    void Start()
    {
        gm = FindAnyObjectByType<GameMasterHomeReturnSceneScript>();
        rb = GetComponent<Rigidbody2D>();

        gm.setIsCatAnimation(true);
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Finish")
        {
            gm.setIsCatAnimation(false);
            gm.setIsTextAnimation(true);
        }
    }
}
