using UnityEngine;

[CreateAssetMenu(menuName = "Range/States/Hard")]
public class HardTargetState : State_Range
{
    public override void EnterState(StateMachine_Range sm)
    {
        sm.GetComponent<DummyMovementController>().SetHard();
    }
}