using UnityEngine;

[CreateAssetMenu(fileName = "SearchingTargets", menuName = "FSM/States/SearchingTargets")]
public class SearchingTargets : State
{
    public override void EnterState(StateMachine sm)
    {
        CompetitiveAI ai = sm.GetComponent<CompetitiveAI>();
        ai.PickRandomPoint();
        ai.MoveTo(ai.randomPoint);
    }

    public override void UpdateState(StateMachine sm)
    {
        CompetitiveAI ai = sm.GetComponent<CompetitiveAI>();

        if (!ai.agent.pathPending && ai.agent.remainingDistance < 0.5f)
        {
            ai.PickRandomPoint();
            ai.MoveTo(ai.randomPoint);
        }
    }
}
