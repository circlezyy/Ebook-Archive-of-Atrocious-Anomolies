using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePage1State : IState
{
    private readonly BookStateMachine stateMachine;
    private readonly BookAI ai;

    public ClosePage1State(BookStateMachine sm)
    {
        stateMachine = sm;
        ai = sm.Owner.GetComponent<BookAI>();
    }

    public void EnterState(GameObject owner)
    {
        ai.fc.moveZPosition(-0.2f, 1);

        ai.p1.rotateToYRotation(11, 150.0f);
        ai.p1.blendCurlDown(65, 150.0f);
        ai.p1.blendCurlUp(0, 150.0f);

        ai.p2.rotateToYRotation(0.0f, 20.0f);
        ai.p2.blendCurlDown(0, 150.0f);
    }

    public void ExitState(GameObject owner)
    {
    }

    public void UpdateState(GameObject owner)
    {
        if (ai.p1.changes == 0)
            stateMachine.ChangeState(stateMachine.page1UpState);
    }
}

