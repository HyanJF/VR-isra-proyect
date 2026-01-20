using UnityEngine;

[CreateAssetMenu(fileName = "HasTargetInSight", menuName = "FSM/Conditions/HasTargetInSight")]
public class HasTargetInSight : Condition
{
    public override bool Check(StateMachine sm)
    {
        CompetitiveAI ai = sm.GetComponent<CompetitiveAI>();
        return ai.IsTargetInRange(ai.shootingRange);
    }
}
