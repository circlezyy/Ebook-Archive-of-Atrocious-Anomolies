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
    }

    public void ExitState(GameObject owner)
    {
    }

    public void UpdateState(GameObject owner)
    {
        if (ai.changes == 0)
        {
            ai.ui.ClearInput();
            stateMachine.ChangeState(stateMachine.notTurningState);
        }
    }
}