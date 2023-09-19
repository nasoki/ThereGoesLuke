using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class CharacterMovement : MonoBehaviour
{
    public static float moveSpeed = 100f;

    private Rigidbody2D rb2d;
    private Vector2 moveVelocity = Vector2.zero;
    private SpriteRenderer playerSpriteRenderer;
    [SerializeField] private Animator animatorController;
    public bool leftButtonActive;
    public bool rightButtonActive;
    public float jump;
    public float raycastDistance = 0.1f;
    public bool onGround;

    

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        animatorController = GetComponent<Animator>();
        moveVelocity.x = moveSpeed * Time.deltaTime;
        leftButtonActive = false;
        rightButtonActive = false;     
    }

    private void Update()
    {
        Debug.Log(onGround);
        if (Input.GetKey("a") || leftButtonActive == true) 
        {
            MoveLeft();
        }
        else if (Input.GetKey("d") || rightButtonActive == true) 
        {
            MoveRight();
        }
        else
        {
            rb2d.AddForce(Vector2.zero);
            animatorController.Play("Player_IdleAnimation");
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (onGround)
            {
                Jump();
            }
        }
    }

    public void LeftPointerUp()
    {
        leftButtonActive = false;
    }
    public void RightPointerUp()
    {
        rightButtonActive = false;
    }
    public void MoveLeft()
    {
        rightButtonActive = false;
        leftButtonActive = true;
        if (playerSpriteRenderer.flipX == false)
        {
            playerSpriteRenderer.flipX = true;
        }
        rb2d.transform.Translate(-moveVelocity * Time.deltaTime);
        animatorController.Play("Player_RunAnimation");
    }
    public void MoveRight()
    {
        leftButtonActive = false;
        rightButtonActive = true;
        if (playerSpriteRenderer.flipX == true)
        {
            playerSpriteRenderer.flipX = false;
        }
        rb2d.transform.Translate(moveVelocity * Time.deltaTime);
        animatorController.Play("Player_RunAnimation");
    }
    public void Jump()
    {
        rb2d.AddForce(new Vector2(rb2d.velocity.x, jump * Time.deltaTime));
        animatorController.Play("Player_JumpAnimation");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            onGround = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        onGround = false;
    }

}
