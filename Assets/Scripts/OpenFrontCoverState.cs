using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFrontCoverState : IState
{
    private readonly BookStateMachine stateMachine;
    private readonly BookAI ai;

    public OpenFrontCoverState(BookStateMachine sm)
    {
        stateMachine = sm;
        ai = sm.Owner.GetComponent<BookAI>();
    }

    public void EnterState(GameObject owner)
    {
        ai.fc.rotateToYRotation(179.9f, 1);
        ai.p1.rotateToYRotation(11.0f, 1);
        ai.p1.blendCurlDown(65, 1);
    }

    public void ExitState(GameObject owner)
    {
    }

    public void UpdateState(GameObject owner)
    {
        if (ai.fc.changes == 0)
            stateMachine.ChangeState(stateMachine.page1UpState);
    }
}

