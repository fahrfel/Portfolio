using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCheckSystem : MonoBehaviour
{
    private static PlayerGroundCheckSystem instance;

    [Header("References")]
    public PlayerInitSystem playerInit;
    public BoxCollider2D playerCollider;

    [Header("Variables")]
    public bool isGrounded;

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

        if (playerInit != null && playerInit.player != null)
        { 
            playerCollider = playerInit.player.GetComponent<BoxCollider2D>();
        }
    }

    private void Update()
    {
        if (playerCollider == null) return;

        isGrounded = playerCollider.IsTouchingLayers(playerInit.playerData.playerClass.groundLayer);
    }
}
