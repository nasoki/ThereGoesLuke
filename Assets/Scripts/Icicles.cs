using UnityEngine;
using System.Collections;


public class Icicles : MonoBehaviour
{
    public Transform raycastOrigin;  // Set this in the Inspector to adjust the ray's starting position
    public float raycastDistance = 5f;  // Set the desired raycast distance in the Inspector
    public Rigidbody2D rb2d;
    [SerializeField] private GameObject deathUI;
    public AudioClip failSound;
    public AudioSource failSoundSource;
    public GameObject player;
    public AudioClip getHurtSoundClip;

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
        if (collision.CompareTag("Player"))
        {
            HealthManager.health--;
            if (HealthManager.health <= 0)
            {
                failSoundSource.clip = failSound;
                failSoundSource.Play();
                deathUI.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                StartCoroutine(GetHurt());
                failSoundSource.clip = getHurtSoundClip;
                failSoundSource.Play();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(6, 7);
        player.GetComponent<Animator>().SetLayerWeight(1, 1);
        yield return new WaitForSeconds(2);
        player.GetComponent<Animator>().SetLayerWeight(1, 0);
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }

}