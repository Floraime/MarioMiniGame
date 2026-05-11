using UnityEngine;

public class AutoPlayerController : MonoBehaviour
{
    public StartSequenceController startSequence;

    public float moveSpeed = 2f;
    public float minX = 2.5f;
    public float maxX = 9f;
    public float changeDirectionTime = 2f;

    private float direction = 1f;
    private float timer = 0f;

    void Start()
    {
        direction = Random.value > 0.5f ? 1f : -1f;
        timer = Random.Range(1f, changeDirectionTime);
    }

    void Update()
    {
        if (startSequence == null) return;
        if (!startSequence.gameStarted) return;

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            direction *= -1f;
            timer = Random.Range(1f, changeDirectionTime);
        }

        Vector3 newPosition = transform.position;
        newPosition.x += direction * moveSpeed * Time.deltaTime;
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        if (newPosition.x <= minX || newPosition.x >= maxX)
        {
            direction *= -1f;
        }

        transform.position = newPosition;
    }
}