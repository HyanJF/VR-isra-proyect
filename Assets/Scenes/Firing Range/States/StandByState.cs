using UnityEngine;

[CreateAssetMenu(menuName = "Range/States/StandBy")]
public class StandByState : State_Range
{
    public override void EnterState(StateMachine_Range sm)
    {
        sm.GetComponent<DummyMovementController>().StandBy();
    }
}