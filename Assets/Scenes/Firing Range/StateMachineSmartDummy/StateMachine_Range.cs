using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class StateMachine_Range : MonoBehaviour
{
    public State_Range initialState;
    public State_Range currentState;

    //[Header("Shared Blackboard")]
    //public MedievalBlackboard blackboard;

    private void Start()
    {
        ChangeState(initialState);
    }
    private void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState(this);
            currentState.CheckTransitions(this);
        }
    }
    public void ChangeState(State_Range state)
    {
        if (currentState == state || state == null)
        {
            return;
        }
        if (currentState != null)
        {
            currentState.ExitState(this);
        }

        currentState = state;
        currentState.EnterState(this);
    }
}