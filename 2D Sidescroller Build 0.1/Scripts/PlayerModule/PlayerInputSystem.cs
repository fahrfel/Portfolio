using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputSystem : MonoBehaviour
{
    private static PlayerInputSystem instance;

    [Header("Refrences")]
    public PlayerInitSystem playerInit;

    [Header("Variables")]
    public bool isRunning;
    public bool isWalking;
    public bool isJumping;

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
            HandleInput();
        }
    }

    private void HandleInput()
    {
        InputWalk();
        InputJump();
        InputRun();
        InputPullPush();
    }

    private void InputWalk()
    {
        if (Input.GetKey(KeyCode.E)) return;

        if (playerInit.playerMovementSystem != null)
        {
            float horizontal = Input.GetAxis("Horizontal");

            playerInit.playerMovementSystem.Walk(horizontal);
            playerInit.playerAnimationManager.AnimWalk(horizontal);
        }
    }
    private void InputJump()
    {
        if (Input.GetButtonDown("Jump") &&
            !(Input.GetKey(KeyCode.E) && playerInit.playerInteractionSystem.currentTarget != null))
        {
            playerInit.playerMovementSystem.Jump();
            playerInit.playerAnimationManager.AnimJump(true);
        }
    }


    private void InputRun()
{
    if (playerInit.playerStateSystem != null)
    {
        var state = playerInit.playerStateSystem.playerState;
        if (state == EnumPlayerState.Pulling || state == EnumPlayerState.Pushing)
        {
            playerInit.playerAnimationManager.AnimRun(0f, false);
            return;
        }
    }

    float horizontal = Input.GetAxisRaw("Horizontal");
    bool isShiftHeld = Input.GetKey(KeyCode.LeftShift);

    if (Mathf.Abs(horizontal) > 0f)
    {
        if (isShiftHeld)
        {
            playerInit.playerMovementSystem.Run(horizontal);
            playerInit.playerAnimationManager.AnimRun(horizontal, true);
        }
        else
        {
            playerInit.playerAnimationManager.AnimRun(horizontal, false);
        }
    }
    else
    {
        playerInit.playerAnimationManager.AnimRun(0f, false);
    }
}

    private void InputPullPush()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.E))
        {
            if (playerInit.playerInteractionSystem.currentTarget != null)
            {
                if (playerInit.playerInteractionSystem.currentTarget.interactiveObject.transform.parent != playerInit.player.transform)
                {
                    playerInit.playerInteractionSystem.AttachCurrentTargetToPlayer();
                }

                float playerX = playerInit.player.transform.position.x;
                float objectX = playerInit.playerInteractionSystem.currentTarget.interactiveObject.transform.position.x;

                if (playerX > objectX)
                {
                    playerInit.playerMovementSystem.Pull(horizontal);
                    playerInit.playerAnimationManager.AnimPushPull(horizontal);
                }
                else
                {
                    playerInit.playerMovementSystem.Push(horizontal);
                    playerInit.playerAnimationManager.AnimPushPull(horizontal);
                }
            }
            else
            {
                playerInit.playerMovementSystem.Walk(horizontal);
                playerInit.playerAnimationManager.AnimWalk(horizontal);
            }
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            playerInit.playerInteractionSystem.DetachCurrentTargetFromPlayer();

            if (playerInit.playerStateSystem != null)
            {
                playerInit.playerStateSystem.playerState = EnumPlayerState.Idle; 
            }

            playerInit.playerAnimationManager.AnimPushPull(0f);

            if (Mathf.Abs(horizontal) > 0f)
            {
                playerInit.playerAnimationManager.AnimWalk(horizontal);
            }
            else
            {
                playerInit.playerAnimationManager.AnimWalk(0f);
            }
        }

    }




}

