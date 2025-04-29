using UnityEngine;

public class CatSpriteAnimations : MonoBehaviour
{
    private Animator animator;
    private enum CharacterState { Idle, Walking, Jumping, Attacking }
    private CharacterState currentState;
    public TouchButton jumpBtn;
    public TouchButton attackBtn;
    public JoystickScript joy;

    private float idleTimer = 0f;
    public float AnimationIdleThreshold = 5f; // Time in seconds before bored animation
    private bool hasTriggeredIdleTooLong = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentState = CharacterState.Idle; // Default state
    }

    void Update()
    {
        HandleState();
    }

    void HandleState()
    {
        //bool isMoving = Input.GetAxis("Horizontal") != 0;
        bool isMoving = joy.x != 0 && joy.y != 0;
        bool isJumping = jumpBtn.isPressed;
        bool isAttacking = attackBtn.isPressed;

        // Determine the new state
        if (isAttacking)
        {
            ChangeState(CharacterState.Attacking);
            Debug.Log("isAttacking");
        }
        else if (isJumping)
        {
            ChangeState(CharacterState.Jumping);
            Debug.Log("isJumping");
        }
        else if (isMoving)
        {
            ChangeState(CharacterState.Walking);
            Debug.Log("isMoving");
        }
        else
        {
            ChangeState(CharacterState.Idle);
            Debug.Log("isIdle");
        }

        HandleIdleTimer();
    }

    void ChangeState(CharacterState newState)
    {
        if (currentState == newState) return; // Avoid redundant state changes

        currentState = newState;

        switch (currentState)
        {
            case CharacterState.Idle:
                animator.SetBool("isMoving", false);
                animator.SetBool("isJumping", false);
                animator.SetBool("isAttacking", false);
                break;

            case CharacterState.Walking:
                animator.SetBool("isMoving", true);
                animator.SetBool("isJumping", false);
                animator.SetBool("isAttacking", false);
                break;

            case CharacterState.Jumping:
                animator.SetBool("isMoving", false);
                animator.SetBool("isJumping", true);
                animator.SetBool("isAttacking", false);
                break;

            case CharacterState.Attacking:
                animator.SetBool("isMoving", false);
                animator.SetBool("isJumping", false);
                animator.SetBool("isAttacking", true);
                Debug.Log("isAttacking");
                Invoke(nameof(ResetToIdle), 0.5f); // Reset after attack animation
                break;
        }
    }

    void HandleIdleTimer()
    {
        if (currentState == CharacterState.Idle)
        {
            idleTimer += Time.deltaTime;

            if (!hasTriggeredIdleTooLong && idleTimer >= AnimationIdleThreshold)
            {
                animator.SetTrigger("IdleTooLong");
                hasTriggeredIdleTooLong = true;
            }
        }
        else
        {
            idleTimer = 0f;
            hasTriggeredIdleTooLong = false;
        }
    }

    void ResetToIdle()
    {
        ChangeState(CharacterState.Idle);
    }
}

