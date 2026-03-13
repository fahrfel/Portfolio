using UnityEngine;

[CreateAssetMenu(fileName = "New Crate", menuName = "ScriptableObjects/InteractiveObjects/Crate", order = 1)]
public class InteractiveCrateClass : InteractiveObjectClass
{
    [Header("IntractiveCrate Settings")]
    public InteractiveCrateType interactiveCrateType;
    public bool isBreakable;
    public bool isPushable;
    public float pushForce;
    public bool isPullable;
    public float pullForce;
    public float crateWeight;

    public override InteractiveObjectClass GetInteractiveObject() { return this; }   
}
