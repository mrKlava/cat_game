using UnityEngine;

public class CatMovementScript : MonoBehaviour
{
    // settings
    [Header("Movement Settings")]
    public float jumpForce = 6f;
    public float moveSpeed = 5f;

    [Header("Controls")]
    public TouchButton attackBtn;
    public TouchButton jumpBtn;
    public JoystickScript joy;

    // states
    public bool isJumping;
    public bool isAttacking;
    public bool isMoving;

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
        // check for inputs each frame
        MoveHorizontal();
        MoveVertical();
        Jump();
        Attack();
    }

    private void FixedUpdate()
    {
        // apply movement
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    private void MoveHorizontal()
    {
        // get horizontal input
        moveInput = joy.x;

        // flip character sprite based on movement direction
        if (moveInput == 0)
        {
            isMoving = false;
        }
        else
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
        float moveVertical = joy.y;

        if (moveVertical > 0)
            Debug.Log("Up");
        if (moveVertical < 0)
            Debug.Log("Down");

    }

    public void Jump()
    {
        // get jump input on press down and verify if not in jump state
        if (jumpBtn.isPressed && !isJumping)
        {
            // set jump state to true 
            isJumping = true;

            // apply impulse force to up
            //rb.AddForce(Vector2.up * jumpForce, (ForceMode2D)ForceMode.Impulse);

            // update linear velocity
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    public void Attack()
    {
        if (attackBtn.isPressed) Debug.Log("Attaaaaaaaaaaaaaaaack, Mrrrr");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;
    }
}
