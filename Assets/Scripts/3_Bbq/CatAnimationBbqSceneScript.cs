using UnityEngine;

public class CatAnimationBbqSceneScript : MonoBehaviour
{
    public float moveSpeed = -3f;

    private GameMasterBbqSceneScript gm;
    private Rigidbody2D rb;

    void Start()
    {
        gm = FindAnyObjectByType<GameMasterBbqSceneScript>();
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
    }
}
