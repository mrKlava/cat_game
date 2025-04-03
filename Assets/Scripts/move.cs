using UnityEngine;
using UnityEngine.UI;


public class move : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 5f;
    public Button A;
    public Button B;
    private Rigidbody2D rb;
    public Joystick joy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D component
        Button btnA = A.GetComponent<Button>();
        Button btnB = B.GetComponent<Button>();
        btnA.onClick.AddListener(Jump);
        btnB.onClick.AddListener(Attack);
        //joy = GetComponent<Joystick>();
    }

    private void FixedUpdate()
    {
        // Get horizontal and vertical input (for example, arrow keys or WASD)
        //float horizontal = Input.GetAxis("Horizontal");  // -1 to 1 (left/right)
        //float vertical = Input.GetAxis("Vertical");      // -1 to 1 (up/down)

        //// Calculate the movement direction
        //Vector2 movement = new Vector2(horizontal, vertical).normalized;


        //// Apply force to the rigidbody
        //rb.AddForce(movement * moveSpeed);

        Vector2 pos = transform.position;
        float dx = pos.x;
        float dy = pos.y;
        float horizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");

        //dont forget to drag the joystick to the move script in editor
        float joyHorizontalMove = joy.Horizontal * moveSpeed;
        float joyVerticalMove = joy.Vertical * moveSpeed;

        Vector2 joyMovement = new Vector2(joyHorizontalMove, joyVerticalMove).normalized;

        float totalHorizontalMove = (horizontalInput * moveSpeed) + joyHorizontalMove;
        float totalVerticalMove = (VerticalInput * moveSpeed) + joyVerticalMove;

        //flip sprite depending on move direction
        if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Flip Left
        }
        else if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Flip Right
        }


        dx += totalHorizontalMove * moveSpeed * Time.deltaTime;
        dy += totalVerticalMove * moveSpeed * Time.deltaTime;

        pos.x = dx;
        pos.y = dy;
        transform.position = pos;




    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.linearVelocity = Vector2.up * jumpForce;
    }

    private void Attack()
    {
        Debug.Log("Cat has attacked !");
    }
}
