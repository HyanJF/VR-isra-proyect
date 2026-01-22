using UnityEngine;

[CreateAssetMenu(menuName = "Range/States/Regular")]
public class RegularTargetState : State_Range
{
    public override void EnterState(StateMachine_Range sm)
    {
        sm.GetComponent<DummyMovementController>().SetRegular();
    }
}