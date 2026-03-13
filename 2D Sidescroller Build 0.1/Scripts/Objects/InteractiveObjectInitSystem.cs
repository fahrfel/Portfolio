using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using Unity.VisualScripting;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveObjectInitSystem : MonoBehaviour
{
    [Header("General")]
    public GameObject interactiveObject;
    public SpriteRenderer interactiveObjectSpriteRenderer;
    public Rigidbody2D rb;
    public BoxCollider2D boxCollider2D;
    public BoxCollider2D interactionZoneCollider;
    public InteractiveObjectData interactiveObjectData;
    public InteractionZoneSystem interactionZoneSystem;

    public void Awake()
    {
        InitializeGeneral();
    }

    private void InitializeGeneral()
    {
        Debug.Log("Initializing General...");

        if (interactiveObject == null)
        {
            Debug.Log("Looking for InteractiveObject...");
            interactiveObject = transform.parent.parent.parent.gameObject;
            if (interactiveObject != null)
            {
                Debug.Log("InteractiveObject Found!");
                Debug.Log("Initializing InteractiveObject...");
            }
            else
            {
                Debug.Log("InteractiveObject Not Found!");
            }
        }

        if (interactiveObject != null && interactiveObjectSpriteRenderer == null)
        {
            Debug.Log("Looking for InteractiveObject Sprite Renderer...");
            interactiveObjectSpriteRenderer = transform.parent.parent.parent.Find("GTX").GetComponent<SpriteRenderer>();
            if (interactiveObjectSpriteRenderer != null)
            {
                Debug.Log("InteractiveObject Sprite Renderer Found!");
                Debug.Log("Initializing InteractiveObject Sprite Renderer...");
            }
            else
            {
                Debug.Log("InteractiveObject Sprite Renderer Not Found!");
            }
        }

        if (interactiveObject != null && rb == null)
        {
            Debug.Log("Looking for InteractiveObject Rigidbody2D...");
            rb = interactiveObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Debug.Log("InteractiveObject Rigidbody2D Found!");
                Debug.Log("Initializing InteractiveObject Rigidbody2D...");
            }
            else
            {
                Debug.Log("InteractiveObject Rigidbody2D Not Found!");
            }
        }

        if (interactiveObject != null && boxCollider2D == null)
        {
            Debug.Log("Looking for InteractiveObject BoxCollider2D...");
            boxCollider2D = interactiveObject.GetComponent<BoxCollider2D>();
            if (boxCollider2D != null)
            {
                Debug.Log("InteractiveObject BoxCollider2D Found!");
                Debug.Log("Initializing InteractiveObject BoxCollider2D...");
            }
            else
            {
                Debug.Log("InteractiveObject BoxCollider2D Not Found!");
            }
        }

        if (interactiveObject != null && interactionZoneCollider == null)
        {
            Debug.Log("Looking for Interaction Zone Collider...");
            interactionZoneCollider = transform.parent.parent.parent.Find("InteractionZone").GetComponent<BoxCollider2D>();
            if (interactionZoneCollider != null)
            {
                Debug.Log("Interaction Zone Collider Found!");
                Debug.Log("Initializing Interaction Zone Collider...");
            }
            else
            {
                Debug.Log("Interaction Zone Collider Not Found!");
            }
        }

        if (interactiveObject != null && interactiveObjectData == null)
        {
            Debug.Log("Looking for InteractiveObjectData...");
            interactiveObjectData = transform.parent.parent.Find("General/InteractiveObjectData").GetComponent<InteractiveObjectData>();
            if (interactiveObjectData != null)
            {
                Debug.Log("InteractiveObjectData Found!");
                Debug.Log("Initializing InteractiveObjectData...");
            }
            else
            {
                Debug.Log("InteractiveObjectData Not Found!");
            }
        }

        if (interactiveObject != null && interactionZoneSystem == null)
        {
            Debug.Log("Looking for InteractionZoneSystem...");
            interactionZoneSystem = transform.parent.parent.parent.Find("InteractionZone").GetComponent<InteractionZoneSystem>();
            if (interactionZoneSystem != null)
            {
                Debug.Log("InteractionZoneSystem Found!");
                Debug.Log("Initializing InteractionZoneSystem...");
            }
            else
            {
                Debug.Log("InteractionZoneSystem Not Found!");
            }
        }

        Debug.Log("General Initialized!");
    }
}
