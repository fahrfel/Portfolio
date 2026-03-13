using UnityEngine;

public class PlayerInteractionSystem : MonoBehaviour
{
    public static PlayerInteractionSystem instance;

    [Header("Refrences")]
    public PlayerInitSystem playerInit;

    [Header("Temporary Variables")]
    public InteractiveObjectInitSystem currentTarget;

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

    public void SetCurrentTarget(InteractiveObjectInitSystem target)
    {
        currentTarget = target;
        Debug.Log($"[SetCurrentTarget] Current Target set: {target.name}");

        if (playerInit != null && playerInit.interactionText != null)
        {
            string objectName = target.interactiveObjectData.interactiveObjectClass.interactiveObjectName;
            Debug.Log($"[SetCurrentTarget] Interaktiver Name: {objectName}");

            playerInit.interactionText.text = $"Press E to use {objectName}";
            playerInit.interactionText.gameObject.SetActive(true);
        }
    }


    public void ClearCurrentTarget(InteractiveObjectInitSystem target)
    {
        if (currentTarget == target)
        {
            currentTarget = null;

            if (playerInit != null && playerInit.interactionText != null)
            {
                playerInit.interactionText.gameObject.SetActive(false);
            }
        }
    }

    public void AttachCurrentTargetToPlayer()
    {
        if (currentTarget != null && currentTarget.interactiveObject != null)
        {
            var targetGO = currentTarget.interactiveObject;
            var offset = Vector3.zero;

            var objClass = currentTarget.interactiveObjectData.interactiveObjectClass;
            if (objClass != null)
            {
                offset = objClass.attachOffset;

                float playerX = playerInit.player.transform.position.x;
                float objectX = targetGO.transform.position.x;

                if (playerX > objectX)
                {
                    offset.x *= -1;
                }
            }

            targetGO.transform.SetParent(playerInit.player.transform);
            targetGO.transform.localPosition = offset;

            Rigidbody2D rb = targetGO.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.isKinematic = true;
                rb.velocity = Vector2.zero;
            }

            Collider2D playerCollider = playerInit.player.GetComponent<Collider2D>();
            Collider2D objectCollider = targetGO.GetComponent<Collider2D>();
            if (playerCollider != null && objectCollider != null)
            {
                Physics2D.IgnoreCollision(playerCollider, objectCollider, true);
            }

            Debug.Log("Object is connected to Player");
        }
    }

    public void DetachCurrentTargetFromPlayer()
    {
        if (currentTarget != null && currentTarget.interactiveObject != null)
        {
            var targetGO = currentTarget.interactiveObject;
            targetGO.transform.SetParent(null);

            Rigidbody2D rb = targetGO.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.isKinematic = true;
            }

            Collider2D playerCollider = playerInit.player.GetComponent<Collider2D>();
            Collider2D objectCollider = targetGO.GetComponent<Collider2D>();
            if (playerCollider != null && objectCollider != null)
            {
                Physics2D.IgnoreCollision(playerCollider, objectCollider, false);
            }

            Debug.Log("Object is detached from Player");
        }
    }
}
