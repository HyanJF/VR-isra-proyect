using UnityEngine;

[CreateAssetMenu(menuName = "Range/Conditions/Accuracy Above")]
public class AccuracyAboveCondition : Condition_Range
{
    public override bool Check(StateMachine_Range sm)
    {
        var controller = sm.GetComponent<DummyMovementController>();
        return controller.GetCurrentAccuracy() >= controller.hardThreshold;
    }
}
