using UnityEngine;

[CreateAssetMenu(fileName = "HasTargetOutOfRange", menuName = "FSM/Conditions/HasTargetOutOfRange")]
public class HasTargetOutOfRange : Condition
{
    public override bool Check(StateMachine sm)
    {
        CompetitiveAI ai = sm.GetComponent<CompetitiveAI>();

        if (ai.currentTarget == null)
            return true;

        return !ai.IsTargetInRange(ai.shootingRange);
    }
}
