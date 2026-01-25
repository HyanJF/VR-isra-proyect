using UnityEngine;

[CreateAssetMenu(fileName = "HasTargetDiedAndPlayerHasMoreScore", menuName = "FSM/Conditions/HasTargetDiedAndPlayerHasMoreScore")]
public class HasTargetDiedAndPlayerHasMoreScore : Condition
{
    public override bool Check(StateMachine sm)
    {
        CompetitiveAI ai = sm.GetComponent<CompetitiveAI>();

        if (ai == null)
            return false;

        bool targetDead = ai.currentTarget == null;
        bool playerWinning = ai.IsPlayerWinning();

        return targetDead && playerWinning;
    }
}
