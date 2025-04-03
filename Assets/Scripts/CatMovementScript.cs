using UnityEngine;

public class CatMovementScript : MonoBehaviour
{
    // settings
    [Header("Movement Settings")]
    public float jumpForce = 6f;
    public float moveSpeed = 5f;

    // states
    private bool isJumping;
    private bool isMoving;

    private float moveInput;

    // components
    private Rigidbody2D rb;

    void Start()
    {
        // get cat's rb
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        Debug.Log(moveInput);

        // check for inputs each frame
        MoveHorizontal();
        MoveVertical();
        Jump();
    }

    private void FixedUpdate()
    {
        // apply movement
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }
 
    private void MoveHorizontal()
    {
        // get horizontal input
        moveInput = Input.GetAxis("Horizontal");

        // flip character sprite based on movement direction
        if (moveInput == 0)
        {
            isMoving = false;
        } else
        {
            isMoving = true;

            // flip image
            if (moveInput > 0)
                transform.localScale = new Vector2(1, 1);
            if (moveInput < 0)
                transform.localScale = new Vector2(-1, 1);
        }
    }

    private void MoveVertical()
    {
        // Get horizontal input
        float moveVertical = Input.GetAxis("Vertical");

        if (moveVertical > 0)
            Debug.Log("Up");
        if (moveVertical < 0)
            Debug.Log("Down");

    }

    private void Jump()
    {
        // get jump input on press down and verify if not in jump state
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            // set jump state to true 
            isJumping = true;

            // apply impulse force to up
            //rb.AddForce(Vector2.up * jumpForce, (ForceMode2D)ForceMode.Impulse);
            
            // update linear velocity
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;
    }
}
