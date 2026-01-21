using UnityEngine;

[CreateAssetMenu(fileName = "FollowCourse", menuName = "FSM/States/FollowCourse")]
public class FollowCourse : State
{
    private int index;

    public override void EnterState(StateMachine sm)
    {
        index = 0;
        sm.GetComponent<CompetitiveAI>().MoveTo(sm.patrolPoints[index].position);
    }

    public override void UpdateState(StateMachine sm)
    {
        CompetitiveAI ai = sm.GetComponent<CompetitiveAI>();

        if (!ai.agent.pathPending && ai.agent.remainingDistance < 0.5f)
        {
            index = (index + 1) % sm.patrolPoints.Length;
            ai.MoveTo(sm.patrolPoints[index].position);
        }
    }
}
