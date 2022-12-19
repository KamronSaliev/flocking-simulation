using UnityEngine;

public class BehaviorManager : MonoBehaviour
{
    public static BehaviorManager instance;

    public static FlockBehaviorType currentBehaviorType;

    public FlockBehaviorType[] flockBehaviorTypes;

    private void Awake()
    {
        instance = this;

        currentBehaviorType = new FlockBehaviorType();
    }

    public void SelectBehaviorType(int behaviorIndex)
    {
        if (flockBehaviorTypes[behaviorIndex].BehaviorObject == null ||
            flockBehaviorTypes[behaviorIndex].BehaviorType == EBehaviorType.Undefined)
        {
            return;
        }

        currentBehaviorType.BehaviorType = flockBehaviorTypes[behaviorIndex].BehaviorType;
        currentBehaviorType.BehaviorObject = flockBehaviorTypes[behaviorIndex].BehaviorObject;
    }
}