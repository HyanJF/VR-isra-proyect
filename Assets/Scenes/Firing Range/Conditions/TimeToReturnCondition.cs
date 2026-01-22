using UnityEngine;

[CreateAssetMenu(menuName = "Range/Conditions/Time To Return")]
public class TimeToReturnCondition : Condition_Range
{
    public override bool Check(StateMachine_Range sm)
    {
        return sm.GetComponent<DummyMovementController>().TimeToReturn;
    }
}
