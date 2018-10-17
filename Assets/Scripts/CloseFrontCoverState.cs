using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseFrontCoverState : IState
{
    private readonly BookStateMachine stateMachine;
    private readonly BookAI ai;

    public CloseFrontCoverState(BookStateMachine sm)
    {
        stateMachine = sm;
        ai = sm.Owner.GetComponent<BookAI>();
    }

    public void EnterState(GameObject owner)
    {
        ai.fc.rotateToYRotation(0.0f, 150.0f);
        ai.p1.rotateToYRotation(0.0f, 20.0f);
        ai.p1.blendCurlDown(0, 150.0f);
    }

    public void ExitState(GameObject owner)
    {
    }

    public void UpdateState(GameObject owner)
    {
        if (ai.fc.changes == 0)
            stateMachine.ChangeState(stateMachine.closedFrontCoverFacingUpState);
    }
}

