using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public StartSequenceController startSequence;

    public float moveSpeed = 3f;
    public float minX = 2f;
    public float maxX = 6f;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

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
            // Face right
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
        else if (moveDirection < 0)
        {
            // Face left
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }
        else
        {
            // Idle state facing forward
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

        // Character movement
        Vector3 newPosition = transform.position;
        newPosition.x += moveDirection * moveSpeed * Time.deltaTime;

        // Limit movement range
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        transform.position = newPosition;
    }
}