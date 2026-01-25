using UnityEngine;

[CreateAssetMenu(menuName = "Range/States/StandBy")]
public class StandByState : State_Range
{
    public override void EnterState(StateMachine_Range sm)
    {
        var controller = sm.GetComponent<DummyMovementController>();
        var accuracy = sm.GetComponent<DummyAccuracyManager>();

        controller.StandBy();
        accuracy.ResetActivation();
    }
}