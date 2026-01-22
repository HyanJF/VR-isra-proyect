using UnityEngine;

public abstract class Condition_Range : ScriptableObject
{
    public virtual bool Check(StateMachine_Range stateMachine_Range) { return false; }
}
[System.Serializable]
public class Transition_Range
{
    public Condition_Range condition;
    public State_Range state;
}

