using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealInteractables : IState
{
    private readonly BookStateMachine stateMachine;
    private readonly BookAI ai;

    public RevealInteractables(BookStateMachine sm)
    {
        stateMachine = sm;
        ai = sm.Owner.GetComponent<BookAI>();
    }

    public void EnterState(GameObject owner)
    {
        ai.RevealInteractables();
    }

    public void ExitState(GameObject owner)
    {
    }

    public void UpdateState(GameObject owner)
    {
        if (ai.changes == 0)
        {
            //ai.ui.ClearInput();
            //stateMachine.ChangeState(stateMachine.notTurningState);
        }
    }
}