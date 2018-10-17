using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page1UpState : IState
{
    private readonly BookStateMachine stateMachine;
    private readonly BookAI ai;

    public Page1UpState(BookStateMachine sm)
    {
        stateMachine = sm;
        ai = sm.Owner.GetComponent<BookAI>();
    }

    public void EnterState(GameObject owner)
    {
        ai.ui.ClearInput();
    }

    public void ExitState(GameObject owner)
    {
    }

    public void UpdateState(GameObject owner)
    {
        if (ai.ui.turnRight)
        {
            stateMachine.ChangeState(stateMachine.closeFrontCoverState);
        }
        else if (ai.ui.turnLeft)
        {
            stateMachine.ChangeState(stateMachine.openPage1State);
        }
    }
}
