using UnityEngine;

[CreateAssetMenu(fileName = "Shooting", menuName = "FSM/States/Shooting")]
public class Shooting : State
{
    public override void EnterState(StateMachine sm)
    {
        sm.GetComponent<CompetitiveAI>().StopMovement();
    }

    public override void UpdateState(StateMachine sm)
    {
        sm.GetComponent<CompetitiveAI>().ShootTarget();
    }
}
