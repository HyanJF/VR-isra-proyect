using UnityEngine;

[CreateAssetMenu(menuName = "Range/Conditions/Dummy Activated")]
public class DummyActivatedCondition : Condition_Range
{
    public override bool Check(StateMachine_Range sm)
    {
        DummyAccuracyManager accuracyManager =
            sm.GetComponent<DummyAccuracyManager>();

        return accuracyManager != null && accuracyManager.HasBeenActivated;
    }
}
