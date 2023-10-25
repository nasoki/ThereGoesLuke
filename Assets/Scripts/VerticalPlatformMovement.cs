using UnityEngine;

public class VerticalPlatformMovement : MonoBehaviour
{
    public float speed = 2.0f;  // Speed of movement
    public float distance = 2.0f;  // Distance the platform should move vertically
    public bool initialDirectionUp = true;  // Choose the initial direction

    private Vector2 startPosition;
    private Rigidbody2D rb;

    private Vector2 upPosition;
    private Vector2 downPosition;
    private bool isMovingUp;

    private void Start()
    {
        rb = GetComponent <Rigidbody2D>();
        startPosition = rb.position;

        upPosition = startPosition + Vector2.up * distance;
        downPosition = startPosition - Vector2.up * distance;

        isMovingUp = initialDirectionUp;
    }

    private void FixedUpdate()
    {
        Vector2 targetPosition = isMovingUp ? upPosition : downPosition;

        // Calculate the new position for the platform
        Vector2 newPosition = Vector2.MoveTowards(rb.position, targetPosition, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPosition);

        // Check if the platform has reached its destination and change direction
        if (Vector2.Distance(rb.position, targetPosition) < 0.01f)
        {
            isMovingUp = !isMovingUp;
        }
    }
}
