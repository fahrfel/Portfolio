using UnityEngine;

public class InteractionZoneSystem : MonoBehaviour
{
    [Header("References")]
    public InteractiveObjectInitSystem interactiveObjectInit;

    private void Awake()
    {
        InitializeReferences();
    }

    private void InitializeReferences()
    {
        if (interactiveObjectInit == null)
        {
            interactiveObjectInit = transform.parent.Find("Scripts/Systems/InteractiveObjectInitSystem").GetComponent<InteractiveObjectInitSystem>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"OnTriggerEnter2D von {other.name} mit Tag {other.tag}");
        if (other.CompareTag("Player") && interactiveObjectInit != null && interactiveObjectInit.interactiveObjectData != null)
        {
            var objectData = interactiveObjectInit.interactiveObjectData.interactiveObjectClass;

            if (objectData != null && objectData.isInteractable)
            {
                Debug.Log("Player entered interaction zone of: " + objectData.interactiveObjectName);
                Debug.Log("Try to set CurrentTarget...");
                PlayerInteractionSystem.instance?.SetCurrentTarget(interactiveObjectInit);
                Debug.Log("SetCurrentTarget aufgerufen.");

            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log($"OnTriggerExit2D von {other.name} mit Tag {other.tag}");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player left interaction zone.");
            PlayerInteractionSystem.instance?.ClearCurrentTarget(interactiveObjectInit);
        }
    }
}

