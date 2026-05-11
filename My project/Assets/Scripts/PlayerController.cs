using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public StartSequenceController startSequence;

    public float moveSpeed = 3f;
    public float minX = 2f;
    public float maxX = 6f;

    public float jumpHeight = 1.5f;
    public float jumpSpeed = 5f;

    private Animator animator;

    private Vector3 startPosition;
    private bool isJumping = false;
    private float jumpProgress = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();

        startPosition = transform.position;

        // Face forward at the start
        transform.rotation = Quaternion.Euler(0f, 180f, 0f);
    }

    void Update()
    {
        if (startSequence == null) return;
        if (!startSequence.gameStarted) return;

        float moveDirection = 0f;

        // Move left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection = -1f;
        }

        // Move right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection = 1f;
        }

        // Update running animation
        if (animator != null)
        {
            animator.SetBool("IsRunning", moveDirection != 0);
        }

        // Character rotation
        if (moveDirection > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
        else if (moveDirection < 0)
        {
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

        // Character movement
        Vector3 newPosition = transform.position;
        newPosition.x += moveDirection * moveSpeed * Time.deltaTime;
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        transform.position = newPosition;

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            jumpProgress = 0f;

            if (animator != null)
            {
                animator.SetBool("IsJumping", true);
            }
        }

        if (isJumping)
        {
            jumpProgress += Time.deltaTime * jumpSpeed;

            float jumpY = Mathf.Sin(jumpProgress) * jumpHeight;

            Vector3 jumpPosition = transform.position;
            jumpPosition.y = startPosition.y + jumpY;
            transform.position = jumpPosition;

            if (jumpProgress >= Mathf.PI)
            {
                isJumping = false;

                Vector3 finalPosition = transform.position;
                finalPosition.y = startPosition.y;
                transform.position = finalPosition;

                if (animator != null)
                {
                    animator.SetBool("IsJumping", false);
                }
            }
        }
    }
}