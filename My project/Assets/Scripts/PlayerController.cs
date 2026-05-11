using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public StartSequenceController startSequence;

    public float moveSpeed = 3f;
    public float minX = 2f;
    public float maxX = 6f;

    void Update()
    {
        if (startSequence == null) return;
        if (!startSequence.gameStarted) return;

        float moveDirection = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection = -1f;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection = 1f;
        }

        Vector3 newPosition = transform.position;
        newPosition.x += moveDirection * moveSpeed * Time.deltaTime;
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        transform.position = newPosition;
    }
}