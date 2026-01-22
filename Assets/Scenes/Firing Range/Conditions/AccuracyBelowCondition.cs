using UnityEngine;

[CreateAssetMenu(menuName = "Range/Conditions/Accuracy Below")]
public class AccuracyBelowCondition : Condition_Range
{
    public override bool Check(StateMachine_Range sm)
    {
        var controller = sm.GetComponent<DummyMovementController>();
        return controller.GetCurrentAccuracy() <= controller.easyThreshold;
    }
}
