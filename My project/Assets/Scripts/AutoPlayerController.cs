using UnityEngine;

public class AutoPlayerController : MonoBehaviour
{
    public StartSequenceController startSequence;

    public float moveSpeed = 2f;
    public float minX = 2.5f;
    public float maxX = 9f;
    public float changeDirectionTime = 2f;

    public float detectionDistance = 3f;

    private float direction = 1f;
    private float timer = 0f;

    // Prevent spam direction changes
    private float obstacleCooldown = 0f;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        direction = Random.value > 0.5f ? 1f : -1f;
        timer = Random.Range(1f, changeDirectionTime);

        transform.rotation = Quaternion.Euler(0f, 180f, 0f);
    }

    void Update()
    {
        if (startSequence == null) return;
        if (!startSequence.gameStarted) return;

        timer -= Time.deltaTime;

        if (obstacleCooldown > 0f)
        {
            obstacleCooldown -= Time.deltaTime;
        }

        // Detection direction
        Vector3 detectionDirection =
            direction > 0 ? Vector3.right : Vector3.left;

        // Ray origin
        Vector3 rayOrigin =
            transform.position + Vector3.up * 0.5f;

        Debug.DrawRay(
            rayOrigin,
            detectionDirection * detectionDistance,
            Color.red
        );

        RaycastHit hit;

        // Detect obstacle
        if (
            obstacleCooldown <= 0f &&
            Physics.Raycast(
                rayOrigin,
                detectionDirection,
                out hit,
                detectionDistance
            )
        )
        {
            if (hit.collider.CompareTag("Obstacle"))
            {
                direction *= -1f;

                obstacleCooldown = 1f;

                timer = Random.Range(
                    1f,
                    changeDirectionTime
                );
            }
        }

        // Random direction change
        if (timer <= 0f)
        {
            direction *= -1f;

            timer = Random.Range(
                1f,
                changeDirectionTime
            );
        }

        // Character movement
        Vector3 newPosition = transform.position;

        newPosition.x +=
            direction *
            moveSpeed *
            Time.deltaTime;

        newPosition.x = Mathf.Clamp(
            newPosition.x,
            minX,
            maxX
        );

        // Reverse direction at limits
        if (
            newPosition.x <= minX ||
            newPosition.x >= maxX
        )
        {
            direction *= -1f;
        }

        transform.position = newPosition;

        // Character rotation
        if (direction > 0)
        {
            transform.rotation =
                Quaternion.Euler(0f, 90f, 0f);
        }
        else
        {
            transform.rotation =
                Quaternion.Euler(0f, -90f, 0f);
        }

        // Running animation
        if (animator != null)
        {
            animator.SetBool(
                "IsRunning",
                true
            );
        }
    }
}