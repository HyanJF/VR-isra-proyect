using UnityEngine;

public abstract class State_Range : ScriptableObject
{
    public Transition_Range[] transitions;

    public virtual void EnterState(StateMachine_Range stateMachine_Range)
    {

    }
    public virtual void ExitState(StateMachine_Range stateMachine_Range) { }

    public virtual void UpdateState(StateMachine_Range stateMachine_Range) { }
    public void CheckTransitions(StateMachine_Range stateMachine_Range)
    {
        foreach (var t in transitions)
        {
            if (t.condition != null && t.condition.Check(stateMachine_Range))
            {
                stateMachine_Range.ChangeState(t.state);
                break;
            }
        }
    }
}

