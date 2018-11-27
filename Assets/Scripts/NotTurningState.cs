using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotTurningState : IState
{
    private readonly BookStateMachine stateMachine;
    private readonly BookAI ai;

    public NotTurningState(BookStateMachine sm)
    {
        stateMachine = sm;
        ai = sm.Owner.GetComponent<BookAI>();
    }

    public void EnterState(GameObject owner)
    {
    }

    public void ExitState(GameObject owner)
    {
    }

    public void UpdateState(GameObject owner)
    {
        //if (ai.ui.turnLeft || ai.ui.turnRight)
        //{
        //    stateMachine.ChangeState(stateMachine.hideInteractables);
       // }
    }
}