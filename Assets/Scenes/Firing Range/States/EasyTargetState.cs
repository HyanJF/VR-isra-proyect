using UnityEngine;

[CreateAssetMenu(menuName = "Range/States/Easy")]
public class EasyTargetState : State_Range
{
    public override void EnterState(StateMachine_Range sm)
    {
        sm.GetComponent<DummyMovementController>().SetEasy();
    }
}