using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementSystem : MonoBehaviour
{
    private static PlayerMovementSystem instance;

    [Header("Refrences")]
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
    public void Walk(float horizontalInput)
    {
        if (playerInit != null)
        {
            float moveSpeed = playerInit.playerData.playerClass.moveSpeed;
            Vector3 move = new Vector3(horizontalInput * moveSpeed * Time.deltaTime, 0f, 0f);

            playerInit.player.transform.Translate(move);
        }    
    }

    public void Jump()
    {
        if (playerInit.playerGroundCheckSystem != null && playerInit.playerGroundCheckSystem.isGrounded)
        {
            float jumpPower = playerInit.playerData.playerClass.jumpPower;

            Vector2 velocity = playerInit.rb.velocity;
            velocity.y = jumpPower;
            playerInit.rb.velocity = velocity;
        }   
    }

    public void Run(float horizontalInput)
    {
        if (playerInit != null)
        {
            float moveSpeed = playerInit.playerData.playerClass.moveSpeed;
            float runSpeed = playerInit.playerData.playerClass.runSpeed;
            Vector3 move = new Vector3(horizontalInput * moveSpeed * Time.deltaTime * runSpeed, 0f, 0f);
            playerInit.player.transform.Translate(move);
        }
    }

    public void Pull(float horizontalInput)
    {
        if (playerInit != null && playerInit.playerInteractionSystem.currentTarget != null)
        {
            var interactiveClass = playerInit.playerInteractionSystem.currentTarget.interactiveObjectData.interactiveObjectClass;
            var crateClass = interactiveClass as InteractiveCrateClass;

            if (crateClass != null && crateClass.isPullable)
            {
                float baseSpeed = playerInit.playerData.playerClass.moveSpeed;
                float reducedSpeed = Mathf.Max(0f, baseSpeed - crateClass.pullForce); 

                Vector3 move = new Vector3(horizontalInput * reducedSpeed * Time.deltaTime, 0f, 0f);
                playerInit.player.transform.Translate(move);

                Debug.Log($"Player pulling");
            }
        }
    }

    public void Push(float horizontalInput)
    {
        if (playerInit != null && playerInit.playerInteractionSystem.currentTarget != null)
        {
            var interactiveClass = playerInit.playerInteractionSystem.currentTarget.interactiveObjectData.interactiveObjectClass;
            var crateClass = interactiveClass as InteractiveCrateClass;

            if (crateClass != null && crateClass.isPushable)
            {
                float baseSpeed = playerInit.playerData.playerClass.moveSpeed;
                float reducedSpeed = Mathf.Max(0f, baseSpeed - crateClass.pushForce); 

                Vector3 move = new Vector3(horizontalInput * reducedSpeed * Time.deltaTime, 0f, 0f);
                playerInit.player.transform.Translate(move);

                Debug.Log($"Player pushing");
            }
        }
    }


}
