using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page2UpState : IState
{
    private readonly BookStateMachine stateMachine;
    private readonly BookAI ai;

    public Page2UpState(BookStateMachine sm)
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
            stateMachine.ChangeState(stateMachine.closePage1State);
        }
        else if (ai.ui.turnLeft)
        {
            //stateMachine.ChangeState(stateMachine.closePage1State);
        }
    }
}
