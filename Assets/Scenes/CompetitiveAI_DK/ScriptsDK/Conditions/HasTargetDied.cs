using UnityEngine;

[CreateAssetMenu(fileName = "HasTargetDied", menuName = "FSM/Conditions/HasTargetDied")]
public class HasTargetDied : Condition
{
    public override bool Check(StateMachine sm)
    {
        CompetitiveAI ai = sm.GetComponent<CompetitiveAI>();

        if (ai.currentTarget == null)
        {
            ai.AddScore(1);
            return true;
        }
        return false;
    }
}
