using UnityEngine;

[CreateAssetMenu(menuName = "Range/Conditions/Reached Start Point")]
public class ReachedStartPointCondition : Condition_Range
{
    public override bool Check(StateMachine_Range sm)
    {
        var controller = sm.GetComponent<DummyMovementController>();
        var agent = controller.agent;

        if (agent.pathPending)
            return false;

        return agent.remainingDistance <= agent.stoppingDistance;
    }
}
