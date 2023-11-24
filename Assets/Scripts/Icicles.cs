using UnityEngine;

public class Icicles : MonoBehaviour
{
    public Transform raycastOrigin;  // Set this in the Inspector to adjust the ray's starting position
    public float raycastDistance = 5f;  // Set the desired raycast distance in the Inspector
    public Rigidbody2D rb2d;
    [SerializeField] private GameObject deathUI;
    void Update()
    {
        // Cast the ray from the raycastOrigin downward
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin.position, Vector2.down, raycastDistance);

        // Draw a debug ray to visualize the raycast
        Debug.DrawRay(raycastOrigin.position, Vector2.down * raycastDistance, Color.red);

        // Check if the ray hits something
        if (hit.collider != null)
        {
            // Check if the hit object has the "Player" tag
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("Hit Player!");
                rb2d.bodyType = RigidbodyType2D.Dynamic;
            }
        }
        else
        {
            Debug.Log("Ray didn't hit anything.");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            deathUI.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}