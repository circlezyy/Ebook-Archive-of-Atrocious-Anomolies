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
        if (ai.ui.turnLeft)
        {
            Debug.Log("Pressed Left");
            stateMachine.ChangeState(stateMachine.backState);
        }
        else if (ai.ui.turnRight)
        {
            Debug.Log("Pressed Right");
            stateMachine.ChangeState(stateMachine.forwardState);
        }
    }
}