using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using Unity.VisualScripting;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInitSystem : MonoBehaviour
{
    private static PlayerInitSystem instance;

    [Header("General")]
    public GameObject player;
    public Animator playerAnim;
    public GameObject playerGTX;
    public SpriteRenderer playerSpriteRenderer;
    public Rigidbody2D rb;
    public PlayerData playerData;

    [Header("Systems")]
    public PlayerMovementSystem playerMovementSystem;  
    public PlayerAnimationSystem playerAnimationSystem;
    public PlayerGroundCheckSystem playerGroundCheckSystem;
    public PlayerInputSystem playerInputSystem;
    public PlayerInteractionSystem playerInteractionSystem;
    public PlayerStateSystem playerStateSystem;

    [Header("Manager")]
    public PlayerAnimationManager playerAnimationManager;
    public PlayerTilemapManager playerTilemapManager;

    [Header("HUD")]
    public GameObject playerHUD;
    public Canvas playerUI;
    public TextMeshProUGUI interactionText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            InitializeGeneral();
            InitializeSystems();
            InitializeManager();
            InitializeHUD();
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void InitializeGeneral()
    {
        Debug.Log("Initializing General...");

        if (player == null)
        {
            Debug.Log("Looking for Player...");
            player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                Debug.Log("Player Found!");
                Debug.Log("Initializing Player...");
            }
            else
            {
                Debug.Log("Player Not Found!");
            }
        }

        if (player != null && playerAnim == null)
        {
            Debug.Log("Looking for Player Animator...");
            playerAnim = transform.parent.parent.parent.Find("GTX").GetComponent<Animator>();
            if (playerAnim != null)
            {
                Debug.Log("Player Animator Found!");
                Debug.Log("Initializing Player Animator...");
            }
            else
            {
                Debug.Log("Player Animator Not Found!");
            }
        }

        if (player != null && playerGTX == null)
        {
            Debug.Log("Looking for Player GTX...");
            playerGTX = transform.parent.parent.parent.Find("GTX").gameObject;
            if (playerGTX != null)
            {
                Debug.Log("Player GTX Found!");
                Debug.Log("Initializing Player GTX...");
            }
            else
            {
                Debug.Log("Player GTX Not Found!");
            }
        }

        if (player != null && playerSpriteRenderer == null)
        {
            Debug.Log("Looking for Player Sprite Renderer...");
            playerSpriteRenderer = transform.parent.parent.parent.Find("GTX").GetComponent<SpriteRenderer>();
            if (playerSpriteRenderer != null)
            {
                Debug.Log("Player Sprite Renderer Found!");
                Debug.Log("Initializing Player Sprite Renderer...");
            }
            else
            {
                Debug.Log("Player Sprite Renderer Not Found!");
            }
        }

        if (player != null && rb == null)
        {
            Debug.Log("Looking for Player Rigidbody2D...");
            rb = player.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Debug.Log("Player Rigidbody2D Found!");
                Debug.Log("Initializing Player Rigidbody2D...");
            }
            else
            {
                Debug.Log("Player Rigidbody2D Not Found!");
            }
        }

        if (player != null && playerData == null)
        {
            Debug.Log("Looking for PlayerData...");
            playerData = transform.parent.parent.parent.Find("Data").GetComponent<PlayerData>();
            if (playerData != null)
            {
                Debug.Log("PlayerData Found!");
                Debug.Log("Initializing PlayerData...");
            }
            else
            {
                Debug.Log("PlayerData Not Found!");
            }
        }

        Debug.Log("General Initialized!");
    }

    private void InitializeSystems()
    {
        Debug.Log("Initializing Systems...");

        if (playerMovementSystem == null)
        {
            Debug.Log("Looking for PlayerMovementSystem...");
            playerMovementSystem = transform.parent.Find("PlayerMovementSystem").GetComponent<PlayerMovementSystem>();
            if (playerMovementSystem != null)
            {
                Debug.Log("PlayerMovementSystem Found!");
                Debug.Log("Initializing PlayerMovementSystem...");
            }
            else
            {
                Debug.Log("PlayerMovementSystem Not Found!");
            }
        }

        if (playerAnimationSystem == null)
        {
            Debug.Log("Looking for PlayerAnimationSystem...");
            playerAnimationSystem = transform.parent.Find("PlayerAnimationSystem").GetComponent<PlayerAnimationSystem>();
            if (playerAnimationSystem != null)
            {
                Debug.Log("PlayerAnimationSystem Found!");
                Debug.Log("Initializing PlayerAnimationSystem...");
            }
            else
            {
                Debug.Log("PlayerAnimationSystem Not Found!");
            }
        }

        if (playerGroundCheckSystem == null)
        {
            Debug.Log("Looking for PlayerGroundCheckSystem...");
            playerGroundCheckSystem = transform.parent.Find("PlayerGroundCheckSystem").GetComponent<PlayerGroundCheckSystem>();
            if (playerGroundCheckSystem != null)
            {
                Debug.Log("PlayerGroundCheckSystem Found!");
                Debug.Log("Initializing PlayerGroundCheckSystem...");
            }
            else
            {
                Debug.Log("PlayerGroundCheckSystem Not Found!");
            }
        }

        if (playerInputSystem == null)
        {
            Debug.Log("Looking for PlayerInputSystem...");
            playerInputSystem = transform.parent.Find("PlayerInputSystem").GetComponent<PlayerInputSystem>();
            if (playerInputSystem != null)
            {
                Debug.Log("PlayerInputSystem Found!");
                Debug.Log("Initializing PlayerInputSystem...");
            }
            else
            {
                Debug.Log("PlayerInputSystem Not Found!");
            }
        }

        if (playerInteractionSystem == null)
        {
            Debug.Log("Looking for PlayerInteractionSystem...");
            playerInteractionSystem = transform.parent.Find("PlayerInteractionSystem").GetComponent<PlayerInteractionSystem>();
            if (playerInteractionSystem != null)
            {
                Debug.Log("PlayerInteractionSystem Found!");
                Debug.Log("Initializing PlayerInteractionSystem...");
            }
            else
            {
                Debug.Log("PlayerInteractionSystem Not Found!");
            }
        }

        if (playerStateSystem == null)
        {
            Debug.Log("Looking for PlayerStateSystem...");
            playerStateSystem = transform.parent.Find("PlayerStateSystem").GetComponent<PlayerStateSystem>();
            if (playerStateSystem != null)
            {
                Debug.Log("PlayerStateSystem Found!");
                Debug.Log("Initializing PlayerStateSystem...");
            }
            else
            {
                Debug.Log("PlayerStateSystem Not Found!");
            }
        }



        Debug.Log("Systems Initialized!");
    }

    private void InitializeManager()
    {
        Debug.Log("Initializing Manager...");

        if (playerAnimationManager == null)
        {
            Debug.Log("Looking for PlayerAnimationManager...");
            playerAnimationManager = transform.parent.parent.Find("Manager/PlayerAnimationManager").GetComponent<PlayerAnimationManager>();
            if (playerAnimationManager != null)
            {
                Debug.Log("PlayerAnimationManager Found!");
                Debug.Log("Initializing PlayerAnimationManager...");
            }
            else
            {
                Debug.Log("PlayerAnimationManager Not Found!");
            }
        }

        if (playerTilemapManager == null)
        {
            Debug.Log("Looking for PlayerTilemapManager...");
            playerTilemapManager = transform.parent.parent.Find("Manager/PlayerTilemapManager").GetComponent<PlayerTilemapManager>();
            if (playerTilemapManager != null)
            {
                Debug.Log("PlayerTilemapManager Found!");
                Debug.Log("Initializing PlayerTilemapManager...");
            }
            else
            {
                Debug.Log("PlayerTilemapManager Not Found!");
            }
        }



        Debug.Log("Manager Initialized!");
    }
    private void InitializeHUD()
    {
        Debug.Log("Initializing HUD...");
        if (playerHUD == null)
        {
            Debug.Log("Looking for Player HUD...");
            playerHUD = transform.parent.parent.parent.Find("HUD").gameObject;
            if (playerHUD != null)
            {
                Debug.Log("Player HUD Found!");
                Debug.Log("Initializing Player HUD...");
            }
            else
            {
                Debug.Log("Player HUD Not Found!");
            }
        }

        if (playerUI == null)
        {
            Debug.Log("Looking for Player UI Canvas...");
            playerUI = playerHUD.transform.Find("PlayerUI").GetComponent<Canvas>();
            if (playerUI != null)
            {
                Debug.Log("Player UI Canvas Found!");
                Debug.Log("Initializing Player UI Canvas...");
            }
            else
            {
                Debug.Log("Player UI Canvas Not Found!");
            }
        }

        if (interactionText == null)
        {
            Debug.Log("Looking for Interaction Text...");
            interactionText = playerUI.transform.Find("InteractionText").GetComponent<TextMeshProUGUI>();
            if (interactionText != null)
            {
                Debug.Log("Interaction Text Found!");
                Debug.Log("Initializing Interaction Text...");
            }
            else
            {
                Debug.Log("Interaction Text Not Found!");
            }
        }
        Debug.Log("HUD Initialized!");
    }
}
