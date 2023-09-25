using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 10.0f;
    private float horizontalMove;
    private bool moveLeft;
    private bool moveRight;
    private bool isGrounded = false;
    private Rigidbody2D rb;
    [SerializeField] private Animator playerAC;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {   
        float moveInput = Input.GetAxis("Horizontal");
        ButtonController();
        //rb.velocity = new Vector2(moveInput * moveSpeed * Time.deltaTime, rb.velocity.y); // keyboard controls
        rb.velocity = new Vector2(horizontalMove * Time.deltaTime, rb.velocity.y); //button controls
        if (rb.velocity.x != 0)
        {
            playerAC.Play("Player_RunAnimation");
        }
        else
        {
            playerAC.Play("Player_IdleAnimation");
        }
        if (rb.velocity.x < 0 && GetComponent<SpriteRenderer>().flipX == false)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (rb.velocity.x > 0 && GetComponent<SpriteRenderer>().flipX == true)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        // Zýplama Kontrolü
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            playerAC.Play("Player_JumpAnimation");
        }
    }

    public void LBClick()
    {
        moveLeft = true;
    }
    public void LBRelease()
    {
        moveLeft = false;
    }
    public void RBClick()
    {
        moveRight = true;
    }
    public void RBRelease()
    {
        moveRight = false;
    }
    public void JumpButton()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        playerAC.Play("Player_JumpAnimation");
    }

    private void ButtonController()
    {
        if (moveLeft)
        {
            horizontalMove = -moveSpeed;
        }
        else if (moveRight)
        {
            horizontalMove = moveSpeed;
        }
        else
        {
            horizontalMove = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
