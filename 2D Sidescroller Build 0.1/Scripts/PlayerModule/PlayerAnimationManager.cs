using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    private static PlayerAnimationManager instance;

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
            return;
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
    public void AnimWalk(float horizontalInput)
    {
        playerInit.playerAnimationSystem.HandleWalkAnimation(horizontalInput);
    }

    public void AnimJump(bool isJumping)
    {
        playerInit.playerAnimationSystem.HandleJumpAnimation(isJumping);
    }

    public void AnimRun(float horizontalInput, bool isRunning)
    {
        playerInit.playerAnimationSystem.HandleRunAnimation(horizontalInput, isRunning);
    }

    public void AnimPushPull(float horizontalInput)
    {
        playerInit.playerAnimationSystem.HandlePushPullAnimation(horizontalInput);
    }
}
