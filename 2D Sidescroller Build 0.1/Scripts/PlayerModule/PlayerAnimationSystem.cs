using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationSystem : MonoBehaviour
{
    private static PlayerAnimationSystem instance;

    [Header("References")]
    public PlayerInitSystem playerInit;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        InitializeReferences();
    }

    private void InitializeReferences()
    {
        if (playerInit == null)
        {
            playerInit = FindObjectOfType<PlayerInitSystem>();
        }
    }

    private void Update()
    {
        if (playerInit != null)
        {
            UpdateJumpState();
        }
    }

    public void HandleWalkAnimation(float horizontalInput)
    {
        bool isWalking = horizontalInput != 0f;

        Animator anim = playerInit.playerAnim;
        SpriteRenderer sr = playerInit.playerSpriteRenderer;

        if (anim != null)
        {
            anim.SetBool("IsWalking", isWalking);
            anim.SetBool("IsIdling", !isWalking);
        }

        if (sr != null && horizontalInput != 0)
        {
            var state = playerInit.playerStateSystem.playerState;
            if (state == EnumPlayerState.Walking || state == EnumPlayerState.Running || state == EnumPlayerState.Jumping)
            {
                sr.flipX = horizontalInput < 0;
            }
        }
    }

    public void HandleJumpAnimation(bool isJumping)
    {
        Animator anim = playerInit.playerAnim;
        if (anim != null)
        {
            anim.SetBool("IsJumping", isJumping);

            if (isJumping)
            {
                anim.SetBool("IsWalking", false);
                anim.SetBool("IsIdling", false);
            }
        }
    }
    private void UpdateJumpState()
    {
        if (playerInit.playerGroundCheckSystem != null)
        {
            bool isGrounded = playerInit.playerGroundCheckSystem.isGrounded;
            Animator anim = playerInit.playerAnim;

            if (anim != null)
            {
                if (isGrounded)
                {
                    anim.SetBool("IsJumping", false);

                    float horizontal = Input.GetAxis("Horizontal");
                    anim.SetBool("IsWalking", horizontal != 0);
                    anim.SetBool("IsIdling", horizontal == 0);
                }
                else
                {
                    anim.SetBool("IsJumping", true);
                    anim.SetBool("IsWalking", false);
                    anim.SetBool("IsIdling", false);
                }
            }
        }
    }

    public void HandleRunAnimation(float horizontalInput, bool isRunningKeyPressed)
    {
        Animator anim = playerInit.playerAnim;
        if (anim == null) return;

        bool isMoving = Mathf.Abs(horizontalInput) > 0f;

        bool isRunning = isRunningKeyPressed && isMoving;
        bool isWalking = isMoving && !isRunning;

        anim.SetBool("IsRunning", isRunning);
        anim.SetBool("IsWalking", isWalking);
        anim.SetBool("IsIdling", !isMoving && !anim.GetBool("IsJumping"));

        SpriteRenderer sr = playerInit.playerSpriteRenderer;
        if (sr != null && isMoving)
        {
            var state = playerInit.playerStateSystem.playerState;
            if (state == EnumPlayerState.Walking || state == EnumPlayerState.Running || state == EnumPlayerState.Jumping)
            {
                sr.flipX = horizontalInput < 0;
            }
        }
    }

    public void HandlePushPullAnimation(float horizontalInput)
    {
        Animator anim = playerInit.playerAnim;
        SpriteRenderer sr = playerInit.playerSpriteRenderer;

        if (anim == null || sr == null) return;

        var state = playerInit.playerStateSystem.playerState;

        bool isPushing = (state == EnumPlayerState.Pushing);
        bool isPulling = (state == EnumPlayerState.Pulling);

        anim.SetBool("IsPushing", isPushing);
        anim.SetBool("IsPulling", isPulling);

        if (isPushing || isPulling)
        {
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsRunning", false);
            anim.SetBool("IsJumping", false);
            anim.SetBool("IsIdling", false);
        }
        else
        {
            anim.SetBool("IsPushing", false);
            anim.SetBool("IsPulling", false);
        }
    }

}
