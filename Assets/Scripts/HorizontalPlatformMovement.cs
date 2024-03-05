using UnityEngine;

public class HorizontalPlatformMovement : MonoBehaviour
{
    public float speed = 2.0f;  // Speed of movement
    public float distance = 2.0f;  // Distance the platform should move horizontally
    public bool initialDirectionRight = true;  // Choose the initial direction

    private Vector2 startPosition;
    private Rigidbody2D rb;

    private Vector2 leftPosition;
    private Vector2 rightPosition;
    private bool isMovingRight;

    private void Start()
    {
        rb = GetComponent <Rigidbody2D>();
        startPosition = rb.position;

        leftPosition = startPosition - Vector2.right * distance;
        rightPosition = startPosition + Vector2.right * distance;

        isMovingRight = initialDirectionRight;
    }

    private void FixedUpdate()
    {
        Vector2 targetPosition = isMovingRight ? rightPosition : leftPosition;

        // Calculate the new position for the platform
        Vector2 newPosition = Vector2.MoveTowards(rb.position, targetPosition, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPosition);

        // Check if the platform has reached its destination and change direction
        if (Vector2.Distance(rb.position, targetPosition) < 0.01f)
        {
            isMovingRight = !isMovingRight;
        }
    }

}
