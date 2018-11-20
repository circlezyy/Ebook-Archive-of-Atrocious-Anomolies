using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideInteractables : IState
{
    private readonly BookStateMachine stateMachine;
    private readonly BookAI ai;

    public HideInteractables(BookStateMachine sm)
    {
        stateMachine = sm;
        ai = sm.Owner.GetComponent<BookAI>();
    }

    public void EnterState(GameObject owner)
    {
        ai.HideInteractables();
    }

    public void ExitState(GameObject owner)
    {
    }

    public void UpdateState(GameObject owner)
    {
        if (ai.changes == 0)
        {
            if (ai.ui.turnLeft)
            {
                stateMachine.ChangeState(stateMachine.backState);
            }
            else if (ai.ui.turnRight)
            {
                stateMachine.ChangeState(stateMachine.forwardState);
            }
        }
    }
}
