using UnityEngine;

[CreateAssetMenu(fileName = "HasDetectedTarget", menuName = "FSM/Conditions/HasDetectedTarget")]
public class HasDetectedTarget : Condition
{
    public override bool Check(StateMachine sm)
    {
        CompetitiveAI ai = sm.GetComponent<CompetitiveAI>();
        Transform t = ai.FindNearestDummy();

        if (t != null)
        {
            ai.currentTarget = t;
            return true;
        }
        return false;
    }
}
