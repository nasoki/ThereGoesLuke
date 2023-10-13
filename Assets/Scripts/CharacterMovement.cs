using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 10.0f;
    private float horizontalMove;
    private bool moveLeft;
    private bool moveRight;
    private bool isGrounded = false;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    [SerializeField] private Animator playerAC;
    private float sizeX = 0.81f;
    private float offsetX = 0.02f;
    private Vector2 originalSize;
    private Vector2 originalOffset;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        originalOffset = boxCollider.offset;
        originalSize = boxCollider.size;
    }

    private void Update()
    {
        Debug.Log(isGrounded);
        float moveInput = Input.GetAxis("Horizontal");
        ButtonController();
        //rb.velocity = new Vector2(moveInput * moveSpeed * Time.deltaTime, rb.velocity.y); // keyboard controls
        rb.velocity = new Vector2(horizontalMove * Time.deltaTime, rb.velocity.y); //button controls
        if (rb.velocity.x != 0)
        {
            playerAC.Play("Player_RunAnimation");
        }
        else if (!isGrounded)
        {
            
            playerAC.Play("Player_JumpAnimation");
        }
        else
        {
            playerAC.Play("Player_IdleAnimation");
        }
        if (rb.velocity.x < 0 && GetComponent<SpriteRenderer>().flipX == false)
        {
            spriteRenderer.flipX = true;
        }
        else if (rb.velocity.x > 0 && GetComponent<SpriteRenderer>().flipX == true)
        {
            spriteRenderer.flipX = false;
        }

        // Zýplama Kontrolü
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            
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
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            //playerAC.Play("Player_JumpAnimation");
        }
    }

    private void ButtonController()
    {
        if (moveLeft)
        {
            boxCollider.offset = new Vector2 (offsetX, boxCollider.offset.y);
            boxCollider.size = new Vector2(sizeX, boxCollider.size.y);
            horizontalMove = -moveSpeed;
        }
        else if (moveRight)
        {
            boxCollider.offset = originalOffset;
            boxCollider.size = originalSize;
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
