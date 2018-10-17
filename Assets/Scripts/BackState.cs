using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackState : IState
{
    private readonly BookStateMachine stateMachine;
    private readonly BookAI ai;

    public BackState(BookStateMachine sm)
    {
        stateMachine = sm;
        ai = sm.Owner.GetComponent<BookAI>();
    }

    public void EnterState(GameObject owner)
    {
        ai.TurnBack();
        stateMachine.ChangeState(stateMachine.notTurningState);
    }

    public void ExitState(GameObject owner)
    {
    }

    public void UpdateState(GameObject owner)
    {
    }
}