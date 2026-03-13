using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObjectClass : ScriptableObject
{
    [Header("InteractiveObject Data")]
    public Sprite interactiveObjectIcon;
    public GameObject interactiveObjectPrefab;

    [Header("InteractiveObject Info")]
    public string interactiveObjectName;
    public string interactiveObjectID;

    [Header("InteractiveObject Settings")]
    public InteractiveObjectType interactiveObjectType;
    public LayerMask interactionLayer;
    public bool isInteractable;
    public float interactionRadius;
    public Vector3 attachOffset = Vector3.zero;


    public virtual InteractiveObjectClass GetInteractiveObject() { return this; }
    public virtual InteractiveCrateClass GetInteractiveCrate() { return null; }
}
    
