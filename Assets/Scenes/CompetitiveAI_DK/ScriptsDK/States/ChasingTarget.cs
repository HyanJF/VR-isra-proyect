using UnityEngine;

[CreateAssetMenu(fileName = "ChasingTarget", menuName = "FSM/States/ChasingTarget")]
public class ChasingTarget : State
{
    public override void UpdateState(StateMachine sm)
    {
        CompetitiveAI ai = sm.GetComponent<CompetitiveAI>();

        if (ai.currentTarget == null) return;

        ai.MoveTo(ai.currentTarget.position);
    }
}
