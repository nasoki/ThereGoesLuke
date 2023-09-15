using UnityEditor.Animations;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public static float moveSpeed = 5f;

    private CharacterController characterController;
    private Vector2 moveVelocity = Vector2.zero;
    private SpriteRenderer playerSpriteRenderer;
    [SerializeField] private Animator animatorController;
    

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        animatorController = GetComponent<Animator>();
        moveVelocity.x = moveSpeed * Time.deltaTime;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            if(playerSpriteRenderer.flipX == false) 
            {
                playerSpriteRenderer.flipX = true;
            }
            characterController.Move(-moveVelocity);
            animatorController.Play("Player_RunAnimation");
        }
        else if (Input.GetKey(KeyCode.RightArrow)) 
        {
            if(playerSpriteRenderer.flipX == true)
            {
                playerSpriteRenderer.flipX = false;
            }
            characterController.Move(moveVelocity);
            animatorController.Play("Player_RunAnimation");
        }
        else
        {
            animatorController.Play("Player_IdleAnimation");
        }
    }
}
