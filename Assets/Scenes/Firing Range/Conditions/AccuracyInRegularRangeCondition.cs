using UnityEngine;

[CreateAssetMenu(menuName = "Range/Conditions/Accuracy In Regular Range")]
public class AccuracyInRegularRangeCondition : Condition_Range
{
    public override bool Check(StateMachine_Range sm)
    {
        var controller = sm.GetComponent<DummyMovementController>();
        float accuracy = controller.GetCurrentAccuracy();

        return accuracy > controller.easyThreshold &&
               accuracy < controller.hardThreshold;
    }
}
