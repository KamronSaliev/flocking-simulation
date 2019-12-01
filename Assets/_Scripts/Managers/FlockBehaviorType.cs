using UnityEngine;

[System.Serializable]
public class FlockBehaviorType
{
    [SerializeField] private EBehaviorType behaviorType = EBehaviorType.Undefined;
    [SerializeField] private FlockBehavior behaviorObject;
    
    public EBehaviorType BehaviorType
    {
        get => behaviorType;
        set => behaviorType = value;
    }
    
    public FlockBehavior BehaviorObject
    {
        get => behaviorObject;
        set => behaviorObject = value;
    }
}

public enum EBehaviorType
{
    Composite,
    Cohesion,
    Alignment,
    Avoidance,
    Attraction,
    Undefined
}