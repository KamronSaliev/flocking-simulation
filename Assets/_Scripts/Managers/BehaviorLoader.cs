using UnityEngine;

public class BehaviorLoader : MonoBehaviour
{
    public void LoadBehavior(int behaviorIndex)
    {
        BehaviorManager.instance.SelectBehaviorType(behaviorIndex);
    }
}
