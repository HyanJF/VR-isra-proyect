using UnityEngine;

[CreateAssetMenu(fileName = "HasPlayerMoreScore", menuName = "FSM/Conditions/HasPlayerMoreScore")]
public class HasPlayerMoreScore : Condition
{
    public override bool Check(StateMachine sm)
    {
        return sm.GetComponent<CompetitiveAI>().IsPlayerWinning();
    }
}
