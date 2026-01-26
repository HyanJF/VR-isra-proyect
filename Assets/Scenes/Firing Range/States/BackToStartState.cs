using UnityEngine;

[CreateAssetMenu(menuName = "Range/States/BackToStart")]
public class BackToStartState : State_Range
{
    public override void EnterState(StateMachine_Range sm)
    {
        sm.GetComponent<DummyMovementController>().GoBackToStart();
    }
}