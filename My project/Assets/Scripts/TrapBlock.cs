using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class TrapBlock : MonoBehaviour
{
    public float topY = 4f;
    public float bottomY = 1f;
    public float speed = 2f;

    private Rigidbody rb;
    private bool goingDown = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.useGravity = false;
        rb.isKinematic = true;

        rb.constraints =
            RigidbodyConstraints.FreezePositionX |
            RigidbodyConstraints.FreezePositionZ |
            RigidbodyConstraints.FreezeRotation;
    }

    void FixedUpdate()
    {
        float targetY = goingDown ? bottomY : topY;

        Vector3 current = rb.position;
        Vector3 target = new Vector3(current.x, targetY, current.z);

        Vector3 newPos = Vector3.MoveTowards(current, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        if (Mathf.Abs(newPos.y - targetY) < 0.05f)
        {
            goingDown = !goingDown;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            goingDown = false; // 
        }
    }
    void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        // Hide the player when hit by the box
        other.gameObject.SetActive(false);
    }
}
}