using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject deathUI;
    [SerializeField] private Animator animatorController;
    public AudioClip failSound;
    public AudioSource failSoundSource;
    private Rigidbody2D rb;
    public float moveSpeed = 2.0f;
    public float moveDistance = 4.0f;
    private SpriteRenderer rbSprite;
    public GameObject player;
    public AudioClip getHurtSoundClip;

    private Vector2 originalPosition;
    private Vector2 rightmostPosition;
    private bool movingRight = true;

    private void Start()
    {
        rbSprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        originalPosition = rb.position;
        rightmostPosition = originalPosition + new Vector2(moveDistance, 0);
        StartCoroutine(MoveLeftAndRight());
        rbSprite.flipX = true;
        deathUI.SetActive(false);
    }

    private IEnumerator MoveLeftAndRight()
    {
        yield return new WaitForSeconds(2.0f); // Wait for 2 seconds before starting movement.

        while (true)
        {
            if (movingRight)
            {
                if (!rbSprite.flipX)
                {
                    rbSprite.flipX = true;
                }
                animatorController.Play("Enemy_Run");
                // Move to the right
                rb.position = Vector2.MoveTowards(rb.position, rightmostPosition, moveSpeed * Time.deltaTime);

                // If the enemy reaches the rightmost position, wait for 3 seconds
                if (Vector2.Distance(rb.position, rightmostPosition) < 0.01f)
                {
                    animatorController.Play("Enemy_Idle");
                    yield return new WaitForSeconds(3.0f);
                }
            }
            else
            {
                if (rbSprite.flipX)
                {
                    rbSprite.flipX = false;
                }
                animatorController.Play("Enemy_Run");
                // Move to the left
                rb.position = Vector2.MoveTowards(rb.position, originalPosition, moveSpeed * Time.deltaTime);

                // If the enemy reaches the original position, wait for 3 seconds
                if (Vector2.Distance(rb.position, originalPosition) < 0.01f)
                {
                    animatorController.Play("Enemy_Idle");
                    yield return new WaitForSeconds(3.0f);
                }
            }

            // Change direction when reaching the target position
            if (Vector2.Distance(rb.position, (movingRight ? rightmostPosition : originalPosition)) < 0.01f)
            {
                movingRight = !movingRight;
            }
            yield return null;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HealthManager.health--;
            if(HealthManager.health <= 0)
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
