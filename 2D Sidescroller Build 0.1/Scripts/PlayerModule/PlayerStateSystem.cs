using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateSystem : MonoBehaviour
{
    private static PlayerStateSystem instance;

    [Header("References")]
    public PlayerInitSystem playerInit;

    [Header("Player State")]
    public EnumPlayerFacingDirection playerFacingDirection;
    public EnumPlayerState playerState;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
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
        UpdatePlayerState();
        UpdateFacingDirection();
    }

    private void UpdatePlayerState()
    {
        if (playerInit == null) return;

        var input = playerInit.playerInputSystem;
        var movement = playerInit.playerMovementSystem;
        var interaction = playerInit.playerInteractionSystem;
        var groundCheck = playerInit.playerGroundCheckSystem;

        if (input == null || movement == null || interaction == null || groundCheck == null) return;

        float horizontal = Input.GetAxisRaw("Horizontal");
        bool isRunningKey = Input.GetKey(KeyCode.LeftShift);
        bool isPullPushKey = Input.GetKey(KeyCode.E);
        bool isJumpPressed = Input.GetButtonDown("Jump");

        bool isGrounded = groundCheck.isGrounded;

        if (isPullPushKey && interaction.currentTarget != null)
        {
            float playerX = playerInit.player.transform.position.x;
            float objectX = interaction.currentTarget.interactiveObject.transform.position.x;

            bool playerIsLeftOfObject = playerX < objectX;

            if (playerIsLeftOfObject)
            {
                if (horizontal > 0)
                {
                    playerState = EnumPlayerState.Pushing;
                }
                else if (horizontal < 0)
                {
                    playerState = EnumPlayerState.Pulling;
                }
                else
                {
                    playerState = EnumPlayerState.Idle;
                }
            }
            else 
            {
                if (horizontal < 0)
                {
                    playerState = EnumPlayerState.Pushing;
                }
                else if (horizontal > 0)
                {
                    playerState = EnumPlayerState.Pulling;
                }
                else
                {
                    playerState = EnumPlayerState.Idle;
                }
            }
        }
        else if (!isGrounded)
        {
            playerState = EnumPlayerState.Jumping;
        }
        else if (Mathf.Abs(horizontal) > 0f)
        {
            playerState = isRunningKey ? EnumPlayerState.Running : EnumPlayerState.Walking;
        }
        else
        {
            playerState = EnumPlayerState.Idle;
        }
    }


    private void UpdateFacingDirection()
    {
        if (playerState == EnumPlayerState.Pulling || playerState == EnumPlayerState.Pushing)
        {
            return;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal < 0)
        {
            playerFacingDirection = EnumPlayerFacingDirection.Left;
        }
        else if (horizontal > 0)
        {
            playerFacingDirection = EnumPlayerFacingDirection.Right;
        }
    }

}


