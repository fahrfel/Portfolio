using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [Header("References")]
    public GameObject player;

    [Header("Camera Settings")]
    public Vector3 offset;
    public float minHeight = 0f;

    private void Start()
    {
        InitializeReferences();
    }

    private void LateUpdate()
    {
        UpdateCameraPosition();
    }

    private void InitializeReferences()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
    }

    private void UpdateCameraPosition()
    {
        if (player != null)
        {
            Vector3 desiredPosition = player.transform.position + offset;
            desiredPosition.y = Mathf.Max(desiredPosition.y, minHeight); 
            transform.position = desiredPosition;
        }
    }
}
